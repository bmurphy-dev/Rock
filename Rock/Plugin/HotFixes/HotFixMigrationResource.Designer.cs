//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rock.Plugin.HotFixes {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class HotFixMigrationResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal HotFixMigrationResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Rock.Plugin.HotFixes.HotFixMigrationResource", typeof(HotFixMigrationResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE [DefinedType]
        ///SET [helptext] = &apos;
        ///Label merge fields are defined with a liquid syntax. Click the &apos;&apos;Show Merge Fields&apos;&apos; button below to view the available merge fields.
        ///&lt;p&gt;
        ///    &lt;a data-toggle=&apos;&apos;collapse&apos;&apos;  href=&apos;&apos;#collapseMergeFields&apos;&apos; class=&apos;&apos;btn btn-action btn-xs&apos;&apos;&gt;Show/Hide Merge Fields&lt;/a&gt;
        ///&lt;/p&gt;
        ///&lt;div id=&apos;&apos;collapseMergeFields&apos;&apos; class=&apos;&apos;panel-collapse collapse&apos;&apos;&gt;
        ///&lt;div class=&apos;&apos;alert alert-info lava-debug&apos;&apos;&gt;
        ///    &lt;div class=&apos;&apos;panel panel-default panel-lavadebug&apos;&apos;&gt;
        ///        &lt;div class=&apos;&apos;panel-head [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _039_MigrationRollupsForV7_2_UpdateCheckInMergefieldDebugInfo {
            get {
                return ResourceManager.GetString("_039_MigrationRollupsForV7_2_UpdateCheckInMergefieldDebugInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DECLARE @simpleCommunicationDetailBlockId INT = (
        /// SELECT TOP 1 Id
        /// FROM [Block]
        /// WHERE [Guid] = &apos;A02F7695-4C6E-44E9-84CB-42E6F51F285F&apos;
        /// )
        ///
        /// DECLARE @wizardCommunicationDetailBlockId INT = (
        /// SELECT TOP 1 Id
        /// FROM [Block]
        /// WHERE [Guid] = &apos;25D890B9-9609-4B63-AD25-4AE427205563&apos;
        /// )
        ///
        ///DECLARE @entityTypeIdBlock INT = (
        /// SELECT TOP 1 Id
        /// FROM EntityType
        /// WHERE [Guid] = &apos;D89555CA-9AE4-4D62-8AF1-E5E463C1EF65&apos;
        /// ) /* Rock.Model.Block */
        ///
        ///
        ///INSERT INTO [Auth] (
        /// EntityTypeid
        /// ,EntityId
        /// ,[Order]
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _041_MigrationRollupsForV7_3_UpdateWizardCommunicationDetailApprovers {
            get {
                return ResourceManager.GetString("_041_MigrationRollupsForV7_3_UpdateWizardCommunicationDetailApprovers", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /*
        ///&lt;doc&gt;
        ///	&lt;summary&gt;
        /// 		This stored procedure detects potential duplicate person records and stores the results in [PersonDuplicate]
        ///	&lt;/summary&gt;
        ///	
        ///	&lt;remarks&gt;	
        ///		Uses the following constants:
        ///			* Group Type - Family: &apos;790E3215-3B10-442B-AF69-616C0DCB998E&apos;
        ///            * Location Type - Home: &apos;8C52E53C-2A66-435A-AE6E-5EE307D9A0DC&apos;
        ///            * Phone Type - Home: &apos;407E7E45-7B2E-4FCD-9605-ECB1339F2453&apos;
        ///            * Phone Type - Cell: &apos;AA8732FB-2CEA-4C76-8D6D-6AAA2C6A4303&apos;
        ///	&lt;/remarks&gt;
        ///	&lt;code&gt;
        ///		EX [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _043_MoreMigrationRollupsForV7_3_spCrm_PersonDuplicateFinder {
            get {
                return ResourceManager.GetString("_043_MoreMigrationRollupsForV7_3_spCrm_PersonDuplicateFinder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /*
        ///&lt;doc&gt;
        ///	&lt;summary&gt;
        /// 		This function converts a comma-delimited string of values into a table of values
        ///        It comes from http://www.sqlservercentral.com/articles/Tally+Table/72993/
        ///	&lt;/summary&gt;
        ///	&lt;returns&gt;
        ///		* id
        ///	&lt;/returns&gt;
        ///	&lt;remarks&gt;
        ///		Used by spFinance_ContributionStatementQuery
        ///	&lt;/remarks&gt;
        ///	&lt;code&gt;
        ///		SELECT * FROM [dbo].[ufnUtility_CsvToTable](&apos;1,3,7,11,13&apos;) 
        ///	&lt;/code&gt;
        ///&lt;/doc&gt;
        ///*/
        ///ALTER FUNCTION [dbo].[ufnUtility_CsvToTable] 
        ///(
        ///	@pString VARCHAR(8000)
        ///)
        ///RETURNS TABLE WITH SCHEMABINDI [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _043_MoreMigrationRollupsForV7_3_ufnUtility_CsvToTable {
            get {
                return ResourceManager.GetString("_043_MoreMigrationRollupsForV7_3_ufnUtility_CsvToTable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DECLARE @AttributeId int = (SELECT [Id] FROM [Attribute] WHERE [Guid] = &apos;7D78DD9F-F5D0-4660-A099-DEFDC70A6664&apos;)
        ///
        ///UPDATE 
        ///    [AttributeValue] 
        ///SET 
        ///    [Value] = REPLACE([Value],&apos;&lt;p&gt;
        ///        &lt;strong&gt;{{ caseworker.FullName }}&lt;/strong&gt; &lt;br /&gt;
        ///        {{ Request.Location.FormattedHtmlAddress }} &lt;br /&gt;
        ///        {% if Request.HomePhoneNumber %}
        ///            Home Phone: {{ Request.HomePhoneNumber }} &lt;br /&gt;
        ///        {% endif %}
        ///        {% if Request.CellPhoneNumber %}
        ///            Cell Phone: {{ Request.Ce [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _047_DataAutomation_FixBenevolenceCaseWorker {
            get {
                return ResourceManager.GetString("_047_DataAutomation_FixBenevolenceCaseWorker", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to DECLARE @ShortLinkMediumValueId int = (SELECT TOP 1 [Id] FROM [DefinedValue] WHERE [Guid] = &apos;371066D5-C5F9-4783-88C8-D9AC8DC67468&apos;)
        ///
        ///IF NOT EXISTS (SELECT * FROM [InteractionChannel]  WHERE [ChannelTypeMediumValueId] = @ShortLinkMediumValueId )
        ///	BEGIN
        ///		DECLARE @ShortlinkEntityTypeId int = (SELECT TOP 1 [Id] FROM [EntityType] WHERE [Name] = &apos;Rock.Model.PageShortLink&apos;)
        ///		
        ///		INSERT INTO [InteractionChannel]
        ///			([Name], [ChannelTypeMediumValueId], [ComponentEntityTypeId], [Guid])
        ///			VALUES
        ///			(&apos;Short  [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _047_DataAutomation_ShortLinkInteractionFix {
            get {
                return ResourceManager.GetString("_047_DataAutomation_ShortLinkInteractionFix", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ALTER PROCEDURE [dbo].[spFinance_GivingAnalyticsQuery_AccountTotals]
        ///	  @StartDate datetime = NULL
        ///	, @EndDate datetime = NULL
        ///	, @AccountIds varchar(max) = NULL
        ///	, @CurrencyTypeIds varchar(max) = NULL
        ///	, @SourceTypeIds varchar(max) = NULL
        ///	, @TransactionTypeIds varchar(max) = NULL
        ///	WITH RECOMPILE
        ///AS
        ///
        ///BEGIN
        ///
        ///	SET @StartDate = COALESCE( CONVERT( date, @StartDate ), &apos;1900-01-01&apos; )
        ///	SET @EndDate = COALESCE( @EndDate, &apos;2100-01-01&apos; )
        ///
        ///	DECLARE @AccountTbl TABLE ( [Id] int )
        ///	INSERT INTO @AccountT [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _049_GivingAnalyticsAccounts_AccountTotals {
            get {
                return ResourceManager.GetString("_049_GivingAnalyticsAccounts_AccountTotals", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ALTER PROCEDURE [dbo].[spFinance_GivingAnalyticsQuery_PersonSummary]
        ///	  @StartDate datetime = NULL
        ///	, @EndDate datetime = NULL
        ///	, @MinAmount decimal(18,2) = NULL
        ///	, @MaxAmount decimal(18,2) = NULL
        ///	, @AccountIds varchar(max) = NULL
        ///	, @CurrencyTypeIds varchar(max) = NULL
        ///	, @SourceTypeIds varchar(max) = NULL
        ///	, @TransactionTypeIds varchar(max) = NULL
        ///	WITH RECOMPILE
        ///AS
        ///
        ///BEGIN
        ///
        ///	SET @StartDate = COALESCE( CONVERT( date, @StartDate ), &apos;1900-01-01&apos; )
        ///	SET @EndDate = COALESCE( @EndDate, &apos;2100-01- [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _049_GivingAnalyticsAccounts_PersonSummary {
            get {
                return ResourceManager.GetString("_049_GivingAnalyticsAccounts_PersonSummary", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ALTER PROCEDURE [dbo].[spFinance_GivingAnalyticsQuery_TransactionData]
        ///	  @StartDate datetime = NULL
        ///	, @EndDate datetime = NULL
        ///	, @AccountIds varchar(max) = NULL
        ///	, @CurrencyTypeIds varchar(max) = NULL
        ///	, @SourceTypeIds varchar(max) = NULL
        ///	, @TransactionTypeIds varchar(max) = NULL
        ///	WITH RECOMPILE
        ///AS
        ///
        ///BEGIN
        ///
        ///	SET @StartDate = COALESCE( CONVERT( date, @StartDate ), &apos;1900-01-01&apos; )
        ///	SET @EndDate = COALESCE( @EndDate, &apos;2100-01-01&apos; )
        ///
        ///	DECLARE @AccountTbl TABLE ( [Id] int )
        ///	INSERT INTO @Accoun [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _049_GivingAnalyticsAccounts_TransactionData {
            get {
                return ResourceManager.GetString("_049_GivingAnalyticsAccounts_TransactionData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to IF ( SELECT COUNT(*) FROM [LavaShortCode] WHERE [Guid] = &apos;EA1335B7-158F-464F-8994-98C53D4E47FF&apos; ) = 0
        ///BEGIN
        ///INSERT INTO [LavaShortCode]
        ///	([Name], [Description], [Documentation], [IsSystem], [IsActive], [TagName], [Markup], [TagType], [EnabledLavaCommands], [Parameters], [Guid])
        ///	VALUES
        ///	(&apos;Vimeo&apos;,&apos;Creates a responsive Vimeo embed from just a simple video id.&apos;,&apos;&lt;p&gt;Embedding a Vimeo video is easy, right? Well what if you want it to be responsive (adjust with the size of the window)? Or what about 
        ///contro [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _050_MigrationRollupsForV7_4_AddVimeoShortCode {
            get {
                return ResourceManager.GetString("_050_MigrationRollupsForV7_4_AddVimeoShortCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UPDATE [LavaShortCode] 
        ///SET [Markup] = &apos;{%- assign wrapperId = uniqueid -%}
        ///{%- assign firstopen = firstopen | AsBoolean -%}
        ///&lt;div class=&quot;panel-group&quot; id=&quot;accordion-{{ wrapperId }}&quot; role=&quot;tablist&quot; aria-multiselectable=&quot;true&quot;&gt;
        ///  {%- for item in items -%}
        ///      {%- assign isopen = &apos;&apos;&apos;&apos; -%}
        ///      {%- if item.isopen and item.isopen !=&apos;&apos;&apos;&apos; -%}
        ///        {%- assign isopen = item.isopen | AsBoolean -%}
        ///      {%- else -%}
        ///        {%- if forloop.index == 1 and firstopen -%}
        ///            {%- assign isopen = tru [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _050_MigrationRollupsForV7_4_FixAccordionShortCode {
            get {
                return ResourceManager.GetString("_050_MigrationRollupsForV7_4_FixAccordionShortCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to -----------------------------------------------------------------------------------------------------------------------------
        ///-----------------------------------------------------------------------------------------------------------------------------
        ///-- Correct Thank you string for Confirm Account email
        ///UPDATE [SystemEmail]
        ///SET [Body] = 
        ///&apos;{{ &apos;&apos;Global&apos;&apos; | Attribute:&apos;&apos;EmailHeader&apos;&apos; }}
        ///
        ///{{ Person.FirstName }},&lt;br/&gt;&lt;br/&gt;
        ///
        ///Thank you for creating an account at {{ &apos;&apos;Global&apos;&apos; | Attribute:&apos;&apos;OrganizationNam [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _050_MigrationRollupsForV7_4_FixThankyouAndOngoingHyphenations {
            get {
                return ResourceManager.GetString("_050_MigrationRollupsForV7_4_FixThankyouAndOngoingHyphenations", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to -- EXECUTE [dbo].[spAnalytics_ETL_Campus] 
        ///ALTER PROCEDURE [dbo].spAnalytics_ETL_Campus
        ///AS
        ///BEGIN
        ///	DECLARE @RowsUpdated INT = 0
        ///		,@RowsInserted INT = 0
        ///
        ///	INSERT INTO AnalyticsSourceCampus (
        ///		[CampusId]
        ///		,[Name]
        ///		,[Description]
        ///		,[IsActive]
        ///		,[ShortCode]
        ///		,[Url]
        ///		,[LocationId]
        ///		,[PhoneNumber]
        ///		,[LeaderPersonAliasId]
        ///		,[ServiceTimes]
        ///		,[Order]
        ///		,[Count]
        ///		,[Guid]
        ///		)
        ///	SELECT [Id]
        ///		,[Name]
        ///		,[Description]
        ///		,ISNULL([IsActive], 0)
        ///		,[ShortCode]
        ///		,[Url]
        ///		,[LocationId] [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _050_MigrationRollupsForV7_4_spAnalytics_ETL_Campus {
            get {
                return ResourceManager.GetString("_050_MigrationRollupsForV7_4_spAnalytics_ETL_Campus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ////*
        ///&lt;doc&gt;
        /// &lt;summary&gt;
        ///   This stored procedure detects potential duplicate person records and stores the results in [PersonDuplicate]
        /// &lt;/summary&gt;
        /// 
        /// &lt;remarks&gt; 
        ///  Uses the following constants:
        ///   * Group Type - Family: &apos;790E3215-3B10-442B-AF69-616C0DCB998E&apos;
        ///            * Location Type - Home: &apos;8C52E53C-2A66-435A-AE6E-5EE307D9A0DC&apos;
        ///            * Phone Type - Home: &apos;AA8732FB-2CEA-4C76-8D6D-6AAA2C6A4303&apos;
        ///            * Phone Type - Cell: &apos;407E7E45-7B2E-4FCD-9605-ECB1339F2453&apos;
        /// &lt;/remarks&gt;
        /// &lt;code&gt;
        ///   [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _050_MigrationRollupsForV7_4_spCrm_PersonDuplicateFinder {
            get {
                return ResourceManager.GetString("_050_MigrationRollupsForV7_4_spCrm_PersonDuplicateFinder", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /*
        ///&lt;doc&gt;
        ///	&lt;summary&gt;
        ///		This procedure merges the data from the non-primary person to the primary person.  It
        ///		is used when merging people in Rock and should never be used outside of that process. 
        ///	&lt;/summary&gt;
        ///
        ///	&lt;returns&gt;
        ///	&lt;/returns&gt;
        ///	&lt;param name=&quot;Old Id&quot; datatype=&quot;int&quot;&gt;The person id of the non-primary Person being merged&lt;/param&gt;
        ///	&lt;param name=&quot;New Id&quot; datatype=&quot;int&quot;&gt;The person id of the primary Person being merged&lt;/param&gt;
        ///	&lt;remarks&gt;	
        ///		Uses the following constants:
        ///			* Group Type - Family: 790E [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _050_MigrationRollupsForV7_4_spCrm_PersonMerge {
            get {
                return ResourceManager.GetString("_050_MigrationRollupsForV7_4_spCrm_PersonMerge", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /*
        ///    &lt;doc&gt;
        ///	    &lt;summary&gt;
        /// 		    This stored procedure updates several attributes related to a person&apos;s
        ///		    giving.
        ///	    &lt;/summary&gt;
        ///	
        ///	    &lt;remarks&gt;	
        ///		    For eRA we only consider adults for the critieria.
        ///	    &lt;/remarks&gt;
        ///	    &lt;code&gt;
        ///		    EXEC [dbo].[spCrm_FamilyAnalyticsGiving] 
        ///	    &lt;/code&gt;
        ///    &lt;/doc&gt;
        ///    */
        ///
        ///    ALTER PROCEDURE [dbo].[spCrm_FamilyAnalyticsGiving]
        ///	
        ///    AS
        ///    BEGIN
        ///	
        ///	    -- configuration of the duration in weeks
        ///	    DECLARE @GivingDurationLongWeeks int = 52
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _052_MigrationRollupsForV8_1_spCrm_FamilyAnalyticsGiving {
            get {
                return ResourceManager.GetString("_052_MigrationRollupsForV8_1_spCrm_FamilyAnalyticsGiving", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /*
        ///&lt;doc&gt;
        ///	&lt;summary&gt;
        /// 		This function returns either the FullName of the specified Person or a list of names of family members
        ///        In the case of a group (family), it will return the names of the adults of the family. If there are no adults in the family, the names of the non-adults will be listed
        ///        Example1 (specific person): Bob Smith 
        ///        Example2 (family with kids): Bill and Sally Jones
        ///        Example3 (different lastnames): Jim Jackson and Betty Sanders
        ///        Example4 (just kids [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _052_MigrationRollupsForV8_1_ufnCrm_GetFamilyTitle {
            get {
                return ResourceManager.GetString("_052_MigrationRollupsForV8_1_ufnCrm_GetFamilyTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /*
        ///&lt;doc&gt;
        ///	&lt;summary&gt;
        /// 		This function returns either the FullName of the specified Person or a list of names of family members
        ///        In the case of a group (family), it will return the names of the adults of the family. If there are no adults in the family, the names of the non-adults will be listed
        ///        Example1 (specific person): Bob Smith 
        ///        Example2 (family with kids): Bill and Sally Jones
        ///        Example3 (different lastnames): Jim Jackson and Betty Sanders
        ///        Example4 (just kids [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _052_MigrationRollupsForV8_1_ufnCrm_GetFamilyTitleIncludeInactive {
            get {
                return ResourceManager.GetString("_052_MigrationRollupsForV8_1_ufnCrm_GetFamilyTitleIncludeInactive", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /*
        ///&lt;doc&gt;
        ///	&lt;summary&gt;
        /// 		This stored procedure returns a data set used by the Rock eRA job to add/remove
        ///		people from being an eRA. It should not be modified as it will be updated in the
        ///		future to meet additional requirements.
        ///
        ///		The goal of the query is to return both those that meet the eRA requirements as well
        ///		as those that are marked as already being an eRA and the criteria to ensure that
        ///		they still should be an era.
        ///	&lt;/summary&gt;
        ///	
        ///	&lt;remarks&gt;	
        ///		For eRA we only consider adults for the c [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _056_MigrationRollupsForV8_4_spCrm_FamilyAnalyticsEraDataset {
            get {
                return ResourceManager.GetString("_056_MigrationRollupsForV8_4_spCrm_FamilyAnalyticsEraDataset", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 
        ///INSERT INTO BinaryFile(
        ///	  [IsTemporary]
        ///	, [IsSystem]
        ///	, [BinaryFileTypeId]
        ///	, [FileName]
        ///	, [MimeType]
        ///	, [Description]
        ///	, [StorageEntityTypeId]
        ///	, [Guid]
        ///	, [StorageEntitySettings]
        ///	, [Path]
        ///	, [FileSize]
        ///)
        ///VALUES (
        ///	  0 --[IsTemporary]
        ///	, 0 --[IsSystem]
        ///	, (SELECT [Id] FROM [BinaryFileType] WHERE [Guid] = &apos;DE0E5C50-234B-474C-940C-C571F385E65F&apos;) --[BinaryFileTypeId]
        ///	, &apos;Install Icon Font on Printer&apos; --[FileName]
        ///	, &apos;text/plain&apos; --[MimeType]
        ///	, &apos;This label installs the Rock icon font, [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _057_MigrationRollupsForV8_5_AddCheck_inLabelToInstallIconFont {
            get {
                return ResourceManager.GetString("_057_MigrationRollupsForV8_5_AddCheck_inLabelToInstallIconFont", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to /*
        ///&lt;doc&gt;
        ///	&lt;summary&gt;
        /// 		This function returns the attendance data needed for the Attendance Badge. If no family role (adult/child)
        ///		is given it is looked up.  If the individual is an adult it will return family attendance if it&apos;s a child
        ///		it will return the individual&apos;s attendance. If a person is in two families once as a child once as an
        ///		adult it will pick the first role it finds.
        ///	&lt;/summary&gt;
        ///
        ///	&lt;returns&gt;
        ///		* AttendanceCount
        ///		* SundaysInMonth
        ///		* Month
        ///		* Year
        ///	&lt;/returns&gt;
        ///	&lt;param name=&quot;P [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _057_MigrationRollupsForV8_5_spCheckin_BadgeAttendance {
            get {
                return ResourceManager.GetString("_057_MigrationRollupsForV8_5_spCheckin_BadgeAttendance", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to USE [Rock-develop]
        ///GO
        ///
        ///SET ANSI_NULLS ON
        ///GO
        ///
        ///SET QUOTED_IDENTIFIER ON
        ///GO
        ///
        ////*
        ///&lt;doc&gt;
        ///	&lt;summary&gt;
        /// 		This stored procedure attempts to update an indivdiual&apos;s first and second visit
        ///		attributes. Below are a few points of interest on the logic.
        ///
        ///		+ A child&apos;s date will only be calculated looking at their check-in data.
        ///		+ An adult&apos;s date will be calculated looking at the check-in data of all the children.
        ///
        ///		+ When calculating a first-visit date it will only write the date if the first checkin [rest of string was truncated]&quot;;.
        /// </summary>
        public static string _057_MigrationRollupsForV8_5_spCrm_FamilyAnalyticsFirstVisitsAttributeUpdate {
            get {
                return ResourceManager.GetString("_057_MigrationRollupsForV8_5_spCrm_FamilyAnalyticsFirstVisitsAttributeUpdate", resourceCulture);
            }
        }
    }
}
