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

    [DisplayName( "Group Edit" )]
    [Category( "Mobile > Groups" )]
    [Description( "Edits the basic settings of a group." )]
    [IconCssClass( "fa fa-users-cog" )]

    #region Block Attributes

    [BooleanField( "Show Group Name",
        Description = "",
        IsRequired = true,
        DefaultBooleanValue = true,
        ControlType = Field.Types.BooleanFieldType.BooleanControlType.Checkbox,
        Key = AttributeKeys.ShowGroupName,
        Order = 0 )]

    [BooleanField( "Enable Group Name Edit",
        Description = "",
        IsRequired = true,
        DefaultBooleanValue = true,
        ControlType = Field.Types.BooleanFieldType.BooleanControlType.Checkbox,
        Key = AttributeKeys.EnableGroupNameEdit,
        Order = 1 )]

    [BooleanField( "Show Description",
        Description = "",
        IsRequired = true,
        DefaultBooleanValue = true,
        ControlType = Field.Types.BooleanFieldType.BooleanControlType.Checkbox,
        Key = AttributeKeys.ShowDescription,
        Order = 2 )]

    [BooleanField( "Enable Description Edit",
        Description = "",
        IsRequired = true,
        DefaultBooleanValue = true,
        ControlType = Field.Types.BooleanFieldType.BooleanControlType.Checkbox,
        Key = AttributeKeys.EnableDescriptionEdit,
        Order = 3 )]

    [BooleanField( "Show Campus",
        Description = "",
        IsRequired = true,
        DefaultBooleanValue = true,
        ControlType = Field.Types.BooleanFieldType.BooleanControlType.Checkbox,
        Key = AttributeKeys.ShowCampus,
        Order = 4 )]

    [BooleanField( "Enable Campus Edit",
        Description = "",
        IsRequired = true,
        DefaultBooleanValue = true,
        ControlType = Field.Types.BooleanFieldType.BooleanControlType.Checkbox,
        Key = AttributeKeys.EnableCampusEdit,
        Order = 5 )]

    [BooleanField( "Show Group Capacity",
        Description = "",
        IsRequired = true,
        DefaultBooleanValue = true,
        ControlType = Field.Types.BooleanFieldType.BooleanControlType.Checkbox,
        Key = AttributeKeys.ShowGroupCapacity,
        Order = 6 )]

    [BooleanField( "Enable Group Capacity Edit",
        Description = "",
        IsRequired = true,
        DefaultBooleanValue = true,
        ControlType = Field.Types.BooleanFieldType.BooleanControlType.Checkbox,
        Key = AttributeKeys.EnableGroupCapacityEdit,
        Order = 7 )]

    [BooleanField( "Show Active Status",
        Description = "",
        IsRequired = true,
        DefaultBooleanValue = true,
        ControlType = Field.Types.BooleanFieldType.BooleanControlType.Checkbox,
        Key = AttributeKeys.ShowActiveStatus,
        Order = 8 )]

    [BooleanField( "Enable Active Status Edit",
        Description = "",
        IsRequired = true,
        DefaultBooleanValue = true,
        ControlType = Field.Types.BooleanFieldType.BooleanControlType.Checkbox,
        Key = AttributeKeys.EnableActiveStatusEdit,
        Order = 9 )]

    [BooleanField( "Show Public Status",
        Description = "",
        IsRequired = true,
        DefaultBooleanValue = true,
        ControlType = Field.Types.BooleanFieldType.BooleanControlType.Checkbox,
        Key = AttributeKeys.ShowPublicStatus,
        Order = 10 )]

    [BooleanField( "Enable Public Status Edit",
        Description = "",
        IsRequired = true,
        DefaultBooleanValue = true,
        ControlType = Field.Types.BooleanFieldType.BooleanControlType.Checkbox,
        Key = AttributeKeys.EnablePublicStatusEdit,
        Order = 11 )]

    [AttributeCategoryField( "Attribute Category",
        Description = "Category of attributes to show and allow editing on.",
        IsRequired = false,
        EntityType = typeof( Group ),
        Key = AttributeKeys.AttributeCategory,
        Order = 12 )]

    [LinkedPage( "Group Detail Page",
        Description = "The group detail page to return to, if not set then the edit page is popped off the navigation stack.",
        IsRequired = false,
        Key = AttributeKeys.GroupDetailPage,
        Order = 13 )]

    #endregion

    public class GroupEdit : RockMobileBlockType
    {
        /// <summary>
        /// The block setting attribute keys for the GroupEdit block.
        /// </summary>
        public static class AttributeKeys
        {
            public const string ShowGroupName = "ShowGroupName";

            public const string EnableGroupNameEdit = "EnableGroupNameEdit";

            public const string ShowDescription = "ShowDescription";

            public const string EnableDescriptionEdit = "EnableDescriptionEdit";

            public const string ShowCampus = "ShowCampus";

            public const string EnableCampusEdit = "EnableCampusEdit";

            public const string ShowGroupCapacity = "ShowGroupCapacity";

            public const string EnableGroupCapacityEdit = "EnableGroupCapacityEdit";

            public const string ShowActiveStatus = "ShowActiveStatus";

            public const string EnableActiveStatusEdit = "EnableActiveStatusEdit";

            public const string ShowPublicStatus = "ShowPublicStatus";

            public const string EnablePublicStatusEdit = "EnablePublicStatusEdit";

            public const string AttributeCategory = "AttributeCategory";

            public const string GroupDetailPage = "GroupDetailPage";
        }

        /// <summary>
        /// The page parameter keys for the GroupEdit block.
        /// </summary>
        public static class PageParameterKeys
        {
            public const string GroupId = "GroupId";
        }

        #region Attribute Properties

        protected bool ShowGroupName => GetAttributeValue( AttributeKeys.ShowGroupName ).AsBoolean();

        protected bool EnableGroupNameEdit => GetAttributeValue( AttributeKeys.EnableGroupNameEdit ).AsBoolean();

        protected bool ShowDescription => GetAttributeValue( AttributeKeys.ShowDescription ).AsBoolean();

        protected bool EnableDescriptionEdit => GetAttributeValue( AttributeKeys.EnableDescriptionEdit ).AsBoolean();

        protected bool ShowCampus => GetAttributeValue( AttributeKeys.ShowCampus ).AsBoolean();

        protected bool EnableCampusEdit => GetAttributeValue( AttributeKeys.EnableCampusEdit ).AsBoolean();

        protected bool ShowGroupCapacity => GetAttributeValue( AttributeKeys.ShowGroupCapacity ).AsBoolean();

        protected bool EnableGroupCapacityEdit => GetAttributeValue( AttributeKeys.EnableGroupCapacityEdit ).AsBoolean();

        protected bool ShowActiveStatus => GetAttributeValue( AttributeKeys.ShowActiveStatus ).AsBoolean();

        protected bool EnableActiveStatusEdit => GetAttributeValue( AttributeKeys.EnableActiveStatusEdit ).AsBoolean();

        protected bool ShowPublicStatus => GetAttributeValue( AttributeKeys.ShowPublicStatus ).AsBoolean();

        protected bool EnablePublicStatusEdit => GetAttributeValue( AttributeKeys.EnablePublicStatusEdit ).AsBoolean();

        protected Guid? AttributeCategory => GetAttributeValue( AttributeKeys.AttributeCategory ).AsGuidOrNull();

        protected Guid? GroupDetailPage => GetAttributeValue( AttributeKeys.GroupDetailPage ).AsGuidOrNull();

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
        public override string MobileBlockType => "Rock.Mobile.Blocks.Group.GroupEdit";

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
    <Label Text=""Group Details"" StyleClass=""heading1"" />
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
                var groupId = RequestContext.GetPageParameter( PageParameterKeys.GroupId ).AsInteger();
                var group = new GroupService( rockContext ).Get( groupId );

                if ( group == null )
                {
                    return "<Rock:NotificationBox HeaderText=\"Error\" Text=\"We couldn't find that group.\" NotificationType=\"Error\" />";
                }
                else if ( !group.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson ) )
                {
                    return "<Rock:NotificationBox HeaderText=\"Error\" Text=\"You are not authorized to edit this group.\" NotificationType=\"Error\" />";
                }

                group.LoadAttributes( rockContext );
                var attributes = GetEditableAttributes( group );

                fieldsContent = BuildCommonFields( group, parameters );
                fieldsContent += MobileHelper.GetEditAttributesXaml( group, attributes, parameters );
            }

            var validatorsContent = parameters.Keys.Select( a => $"<x:Reference>{a}</x:Reference>" );
            var parametersContent = parameters.Select( a => $"<Rock:Parameter Name=\"{a.Key}\" Value=\"{{Binding {a.Value}, Source={{x:Reference {a.Key}}}}}\" />" );

            if ( GroupDetailPage.HasValue )
            {
                content = content.Replace( "##CANCEL##", $"Command=\"{{Binding ReplacePage}}\" CommandParameter=\"{GroupDetailPage}\"" );
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
        /// <param name="group">The group.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>A string containing the XAML that represents the common Group fields.</returns>
        private string BuildCommonFields( Group group, Dictionary<string, string> parameters )
        {
            var sb = new StringBuilder();

            if ( ShowGroupName )
            {
                if ( EnableGroupNameEdit )
                {
                    sb.AppendLine( MobileHelper.GetSingleFieldXaml( $"<Rock:TextBox x:Name=\"name\" Label=\"Name\" IsRequired=\"true\" Text=\"{group.Name.EncodeXml( true )}\" />" ) );
                    parameters.Add( "name", "Text" );
                }
                else
                {
                    sb.AppendLine( MobileHelper.GetReadOnlyFieldXaml( "Name", group.Name ) );
                }
            }

            if ( ShowDescription )
            {
                if ( EnableDescriptionEdit )
                {
                    sb.AppendLine( MobileHelper.GetSingleFieldXaml( $"<Rock:TextBox x:Name=\"description\" Label=\"Description\" IsRequired=\"false\" Text=\"{group.Description.EncodeXml( true )}\" />" ) );
                    parameters.Add( "description", "Text" );
                }
                else
                {
                    sb.AppendLine( MobileHelper.GetReadOnlyFieldXaml( "Description", group.Name ) );
                }
            }

            if ( ShowCampus )
            {
                if ( EnableCampusEdit )
                {
                    sb.AppendLine( MobileHelper.GetSingleFieldXaml( $"<Rock:CampusPicker x:Name=\"campus\" Label=\"Campus\" IsRequired=\"{group.GroupType.GroupsRequireCampus}\" SelectedValue=\"{group.Campus?.Guid.ToStringSafe()}\" />" ) );
                    parameters.Add( "campus", "SelectedValue" );
                }
                else
                {
                    sb.AppendLine( MobileHelper.GetReadOnlyFieldXaml( "Campus", group.Campus.Name ) );
                }
            }

            if ( ShowGroupCapacity && group.GroupType.GroupCapacityRule != GroupCapacityRule.None )
            {
                if ( EnableGroupCapacityEdit )
                {
                    sb.AppendLine( MobileHelper.GetSingleFieldXaml( $"<Rock:NumberBox x:Name=\"capacity\" Label=\"Capacity\" IsRequired=\"false\" Text=\"{group.GroupCapacity}\" />" ) );
                    parameters.Add( "capacity", "Text" );
                }
                else
                {
                    sb.AppendLine( MobileHelper.GetReadOnlyFieldXaml( "Group Capacity", group.Name ) );
                }
            }

            if ( ShowActiveStatus )
            {
                if ( EnableActiveStatusEdit )
                {
                    sb.AppendLine( MobileHelper.GetSingleFieldXaml( $"<Rock:CheckBox x:Name=\"active\" Label=\"Is Active\" IsRequired=\"false\" IsChecked=\"{group.IsActive}\" />", false ) );
                    parameters.Add( "active", "IsChecked" );
                }
                else
                {
                    sb.AppendLine( MobileHelper.GetReadOnlyFieldXaml( "Is Active", group.IsActive ? "Yes" : "No" ) );
                }
            }

            if ( ShowPublicStatus )
            {
                if ( EnablePublicStatusEdit )
                {
                    sb.AppendLine( MobileHelper.GetSingleFieldXaml( $"<Rock:CheckBox x:Name=\"public\" Label=\"Is Public\" IsRequired=\"false\" IsChecked=\"{group.IsPublic}\" />", false ) );
                    parameters.Add( "public", "IsChecked" );
                }
                else
                {
                    sb.AppendLine( MobileHelper.GetReadOnlyFieldXaml( "Is Public", group.IsPublic ? "Yes" : "No" ) );
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Saves the group.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>The response to send back to the client.</returns>
        private CallbackResponse SaveGroup( Dictionary<string, object> parameters )
        {
            using ( var rockContext = new RockContext() )
            {
                var groupId = RequestContext.GetPageParameter( PageParameterKeys.GroupId ).AsInteger();
                var group = new GroupService( rockContext ).Get( groupId );

                if ( group == null || !group.IsAuthorized( Authorization.EDIT, RequestContext.CurrentPerson ) )
                {
                    return new CallbackResponse
                    {
                        Error = "You are not authorized to edit this group."
                    };
                }

                group.LoadAttributes( rockContext );

                //
                // Verify and save all the property values.
                //
                if ( ShowGroupName && EnableGroupNameEdit )
                {
                    group.Name = ( string ) parameters["name"];
                }

                if ( ShowDescription && EnableDescriptionEdit )
                {
                    group.Description = ( string ) parameters["description"];
                }

                if ( ShowCampus && EnableCampusEdit )
                {
                    group.CampusId = CampusCache.Get( ( ( string ) parameters["campus"] ).AsGuid() )?.Id;
                }

                if ( ShowGroupCapacity && EnableGroupCapacityEdit && group.GroupType.GroupCapacityRule != GroupCapacityRule.None )
                {
                    group.GroupCapacity = ( ( string ) parameters["capacity"] ).AsIntegerOrNull();
                }

                if ( ShowActiveStatus && EnableActiveStatusEdit )
                {
                    group.IsActive = ( bool ) parameters["active"];
                }

                if ( ShowPublicStatus && EnablePublicStatusEdit )
                {
                    group.IsPublic = ( bool ) parameters["public"];
                }

                //
                // Save all the attribute values.
                //
                MobileHelper.UpdateEditAttributeValues( group, parameters, GetEditableAttributes( group ) );

                //
                // Save all changes to database.
                //
                rockContext.WrapTransaction( () =>
                {
                    rockContext.SaveChanges();
                    group.SaveAttributeValues( rockContext );
                } );
            }

            if ( GroupDetailPage.HasValue )
            {
                return new CallbackResponse
                {
                    Command = "ReplacePage",
                    CommandParameter = $"{GroupDetailPage}?GroupId={RequestContext.GetPageParameter( PageParameterKeys.GroupId )}"
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
                return SaveGroup( parameters );
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
