﻿// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Rock.Attribute;
using Rock.Data;
using Rock.Mobile;
using Rock.Mobile.Common.Blocks.Content;
using Rock.Model;
using Rock.Security;
using Rock.Web.Cache;

namespace Rock.Blocks.Types.Mobile.Groups
{
    /// <summary>
    /// Displays custom XAML content on the page.
    /// </summary>
    /// <seealso cref="Rock.Blocks.RockMobileBlockType" />

    [DisplayName( "Group Member Edit" )]
    [Category( "Mobile > Groups" )]
    [Description( "Edits a member of a group." )]
    [IconCssClass( "fa fa-user-cog" )]

    #region Block Attributes

    [BooleanField( "Allow Role Change",
        Description = "",
        IsRequired = true,
        DefaultBooleanValue = true,
        ControlType = Field.Types.BooleanFieldType.BooleanControlType.Checkbox,
        Key = AttributeKeys.AllowRoleChange,
        Order = 0 )]

    [BooleanField( "Allow Member Status Change",
        Description = "",
        IsRequired = true,
        DefaultBooleanValue = true,
        ControlType = Field.Types.BooleanFieldType.BooleanControlType.Checkbox,
        Key = AttributeKeys.AllowMemberStatusChange,
        Order = 1 )]

    [BooleanField( "Allow Note Edit",
        Description = "",
        IsRequired = true,
        DefaultBooleanValue = true,
        ControlType = Field.Types.BooleanFieldType.BooleanControlType.Checkbox,
        Key = AttributeKeys.AllowNoteEdit,
        Order = 2 )]

    [AttributeCategoryField( "Attribute Category",
        Description = "Category of attributes to show and allow editing on.",
        IsRequired = false,
        EntityType = typeof( GroupMember ),
        Key = AttributeKeys.AttributeCategory,
        Order = 3 )]

    [LinkedPage( "Member Detail Page",
        Description = "The group member page to return to, if not set then the edit page is popped off the navigation stack.",
        IsRequired = false,
        Key = AttributeKeys.MemberDetailPage,
        Order = 4 )]

    #endregion

    public class GroupMemberEdit : RockMobileBlockType
    {
        /// <summary>
        /// The block setting attribute keys for the GroupMemberEdit block.
        /// </summary>
        public static class AttributeKeys
        {
            public const string AllowRoleChange = "AllowRoleChange";

            public const string AllowMemberStatusChange = "AllowMemberStatusChange";

            public const string AllowNoteEdit = "AllowNoteEdit";

            public const string AttributeCategory = "AttributeCategory";

            public const string MemberDetailPage = "MemberDetailsPage";
        }

        /// <summary>
        /// The page parameter keys for the GroupMemberEdit block.
        /// </summary>
        public static class PageParameterKeys
        {
            public const string GroupMemberId = "GroupMemberId";
        }

        #region Attribute Properties

        protected bool AllowRoleChange => GetAttributeValue( AttributeKeys.AllowRoleChange ).AsBoolean();

        protected bool AllowMemberStatusChange => GetAttributeValue( AttributeKeys.AllowMemberStatusChange ).AsBoolean();

        protected bool AllowNoteEdit => GetAttributeValue( AttributeKeys.AllowNoteEdit ).AsBoolean();

        protected Guid? AttributeCategory => GetAttributeValue( AttributeKeys.AttributeCategory ).AsGuidOrNull();

        protected Guid? MemberDetailPage => GetAttributeValue( AttributeKeys.MemberDetailPage ).AsGuidOrNull();

        #endregion

        #region IRockMobileBlockType Implementation

        /// <summary>
        /// Gets the required mobile application binary interface version required to render this block.
        /// </summary>
        /// <value>
        /// The required mobile application binary interface version required to render this block.
        /// </value>
        public override int RequiredMobileAbiVersion => 1;

        /// <summary>
        /// Gets the class name of the mobile block to use during rendering on the device.
        /// </summary>
        /// <value>
        /// The class name of the mobile block to use during rendering on the device
        /// </value>
        public override string MobileBlockType => "Rock.Mobile.Blocks.Group.GroupMemberEdit";

        /// <summary>
        /// Gets the property values that will be sent to the device in the application bundle.
        /// </summary>
        /// <returns>
        /// A collection of string/object pairs.
        /// </returns>
        public override object GetMobileConfigurationValues()
        {
            //
            // Indicate that we are a dynamic content providing block.
            //
            return new Rock.Mobile.Common.Blocks.Content.Configuration
            {
                Content = null,
                DynamicContent = true
            };
        }

        #endregion

        #region Methods

        /// <summary>
        /// Builds the content to be displayed on the block.
        /// </summary>
        /// <returns>A string containing the XAML content to be displayed.</returns>
        private string BuildContent()
        {
            string content = @"
<StackLayout>
    <Label Text=""Group Member Edit"" StyleClass=""heading1"" />
    <BoxView Color=""#888"" HeightRequest=""1"" Margin=""0 0 12 0"" />

    ##FIELDS##
    
    <Rock:Validator x:Name=""vForm"">
        ##VALIDATORS##
    </Rock:Validator>
    
    <Rock:NotificationBox x:Name=""nbError"" NotificationType=""Error"" />
    
    <Button StyleClass=""btn,btn-primary"" Text=""Save"" Margin=""24 0 0 0"" Command=""{Binding Callback}"">
        <Button.CommandParameter>
            <Rock:CallbackParameters Name=""Save"" Validator=""{x:Reference vForm}"" Notification=""{x:Reference nbError}"">
                ##PARAMETERS##
            </Rock:CallbackParameters>
        </Button.CommandParameter>
    </Button>

    <Button StyleClass=""btn,btn-link"" Text=""Cancel"" ##CANCEL## />
</StackLayout>";

            var parameters = new Dictionary<string, string>();
            string fieldsContent;

            using ( var rockContext = new RockContext() )
            {
                var groupMemberId = RequestContext.GetPageParameter( PageParameterKeys.GroupMemberId ).AsInteger();
                var member = new GroupMemberService( rockContext ).Get( groupMemberId );

                if ( member == null )
                {
                    return "<Rock:NotificationBox HeaderText=\"Error\" Text=\"We couldn't find that member.\" NotificationType=\"Error\" />";
                }
                else if ( !member.Group.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson ) && !member.Group.IsAuthorized( Authorization.MANAGE_MEMBERS, RequestContext.CurrentPerson ) )
                {
                    return "<Rock:NotificationBox HeaderText=\"Error\" Text=\"You are not authorized to edit members of this group.\" NotificationType=\"Error\" />";
                }

                member.LoadAttributes( rockContext );
                var attributes = GetEditableAttributes( member );

                fieldsContent = BuildCommonFields( member, parameters );
                fieldsContent += MobileHelper.GetEditAttributesXaml( member, attributes, parameters );
            }

            var validatorsContent = parameters.Keys.Select( a => $"<x:Reference>{a}</x:Reference>" );
            var parametersContent = parameters.Select( a => $"<Rock:Parameter Name=\"{a.Key}\" Value=\"{{Binding {a.Value}, Source={{x:Reference {a.Key}}}}}\" />" );

            if ( MemberDetailPage.HasValue )
            {
                content = content.Replace( "##CANCEL##", $"Command=\"{{Binding ReplacePage}}\" CommandParameter=\"{MemberDetailPage}\"" );
            }
            else
            {
                content = content.Replace( "##CANCEL##", "Command=\"{Binding PopPage}\"" );
            }

            return content.Replace( "##FIELDS##", fieldsContent )
                .Replace( "##VALIDATORS##", string.Join( string.Empty, validatorsContent ) )
                .Replace( "##PARAMETERS##", string.Join( string.Empty, parametersContent ) );
        }

        /// <summary>
        /// Builds the common fields.
        /// </summary>
        /// <param name="member">The group.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A string containing the XAML that represents the common Group fields.</returns>
        private string BuildCommonFields( GroupMember member, Dictionary<string, string> parameters )
        {
            var sb = new StringBuilder();

            sb.AppendLine( MobileHelper.GetReadOnlyFieldXaml( "Name", member.Person.FullName ) );

            if ( AllowRoleChange )
            {
                var items = GroupTypeCache.Get( member.Group.GroupTypeId )
                    .Roles
                    .Select( a => new KeyValuePair<string, string>( a.Id.ToString(), a.Name ) );

                sb.AppendLine( MobileHelper.GetSingleFieldXaml( MobileHelper.GetDropDownFieldXaml( "role", "Role", member.GroupRoleId.ToString(), true, items ) ) );
                parameters.Add( "role", "SelectedValue" );
            }
            else
            {
                sb.AppendLine( MobileHelper.GetReadOnlyFieldXaml( "Role", member.GroupRole.Name ) );
            }

            if ( AllowMemberStatusChange )
            {
                var items = Enum.GetNames( typeof( GroupMemberStatus ) )
                    .Select( a => new KeyValuePair<string, string>( a, a ) );

                sb.AppendLine( MobileHelper.GetSingleFieldXaml( MobileHelper.GetDropDownFieldXaml( "memberstatus", "Member Status", member.GroupMemberStatus.ToString(), true, items ) ) );
                parameters.Add( "memberstatus", "SelectedValue" );
            }
            else
            {
                sb.AppendLine( MobileHelper.GetReadOnlyFieldXaml( "Member Status", member.GroupMemberStatus.ToString() ) );
            }

            if ( AllowNoteEdit )
            {
                sb.AppendLine( MobileHelper.GetSingleFieldXaml( MobileHelper.GetTextEditFieldXaml( "note", "Note", member.Note, false, true ) ) );
                parameters.Add( "note", "Text" );
            }
            else
            {
                sb.AppendLine( MobileHelper.GetReadOnlyFieldXaml( "Note", member.Note ) );
            }

            return sb.ToString();
        }

        /// <summary>
        /// Saves the group member.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response to send back to the client.</returns>
        private CallbackResponse SaveGroupMember( Dictionary<string, object> parameters )
        {
            using ( var rockContext = new RockContext() )
            {
                var groupMemberId = RequestContext.GetPageParameter( PageParameterKeys.GroupMemberId ).AsInteger();
                var member = new GroupMemberService( rockContext ).Get( groupMemberId );

                if ( member == null || (!member.Group.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson ) && !member.Group.IsAuthorized( Authorization.MANAGE_MEMBERS, RequestContext.CurrentPerson ) ) )
                {
                    return new CallbackResponse
                    {
                        Error = "You are not authorized to edit members of this group."
                    };
                }

                member.LoadAttributes( rockContext );

                //
                // Verify and save all the property values.
                //
                if ( AllowRoleChange )
                {
                    member.GroupRoleId = ( ( string ) parameters["role"] ).AsInteger();
                }

                if ( AllowMemberStatusChange )
                {
                    member.GroupMemberStatus = ( ( string ) parameters["memberstatus"] ).ConvertToEnum<GroupMemberStatus>();
                }

                if ( AllowNoteEdit )
                {
                    member.Note = ( string ) parameters["note"];
                }

                //
                // Save all the attribute values.
                //
                MobileHelper.UpdateEditAttributeValues( member, parameters, GetEditableAttributes( member ) );

                //
                // Save all changes to database.
                //
                rockContext.WrapTransaction( () =>
                {
                    rockContext.SaveChanges();
                    member.SaveAttributeValues( rockContext );
                } );
            }

            if ( MemberDetailPage.HasValue )
            {
                return new CallbackResponse
                {
                    Command = "ReplacePage",
                    CommandParameter = $"{MemberDetailPage}?GroupMemberId={RequestContext.GetPageParameter( PageParameterKeys.GroupMemberId )}"
                };
            }
            else
            {
                return new CallbackResponse
                {
                    Command = "PopPage",
                    CommandParameter = "true"
                };
            }
        }

        /// <summary>
        /// Gets the editable attributes.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="rockContext">The rock context.</param>
        /// <returns></returns>
        private List<AttributeCache> GetEditableAttributes( IHasAttributes entity )
        {
            if ( AttributeCategory.HasValue )
            {
                var category = CategoryCache.Get( AttributeCategory.Value );

                if ( category != null )
                {
                    return entity.Attributes.Values
                        .Where( a => a.CategoryIds.Contains( category.Id ) )
                        .Where( a => a.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson ) )
                        .OrderBy( a => a.Order )
                        .ThenBy( a => a.Name )
                        .ToList();
                }
            }

            return new List<AttributeCache>();
        }

        #endregion

        #region Action Methods

        /// <summary>
        /// Gets the current configuration for this block.
        /// </summary>
        /// <returns>A collection of string/string pairs.</returns>
        [BlockAction]
        public object GetInitialContent()
        {
            return new CallbackResponse
            {
                Content = BuildContent()
            };
        }

        [BlockAction]
        [RockObsolete( "1.10.2" )]
        public object GetCurrentConfig()
        {
            return GetInitialContent();
        }

        /// <summary>
        /// Gets the dynamic XAML content that should be rendered based upon the request.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        [BlockAction]
        public object GetCallbackContent( string command, Dictionary<string, object> parameters )
        {
            if ( command == "Save" )
            {
                return SaveGroupMember( parameters );
            }
            else
            {
                return new CallbackResponse
                {
                    Error = "Invalid command received."
                };
            }
        }

        #endregion
    }
}
