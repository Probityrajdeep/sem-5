<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>
<%==SIM:UserInput:IndentationSize=Number("Indentation size",4)==%>
<%==SIM:UserInput:IndentationChar=Choice("Indentation char",Space,Tab)==%>
<%==SIM:If:Eq(IndentationChar,"Tab")==%><%==SIM:SetTabIndent==%><%==SIM:Else==%><%==SIM:SetSpaceIndent==%><%==SIM:EndIf==%><%==SIM:IndentSize(IndentationSize)==%>

-- Table <%==SIM:Element.Name==%> --------------------------<%==SIM:Line==%>
<%==SIM:ForEach:Element.DocumentationLines==%>
	--<%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:Clear(UsedIndexes)==%>
<%==SIM:IfNot:Union(Element.PreviousState.Indexes,Element.Indexes).IsEmpty==%>
-- Drop old indexes of table <%==SIM:Element.Name==%> ------------------------------<%==SIM:Line==%>
<%==SIM:ForEach(Index):Union(Element.PreviousState.Indexes,Element.Indexes)==%>
<%==SIM:IfNot:IsInList(UsedIndexes,Index.Name)==%>
<%==SIM:Add(UsedIndexes,Index.Name)==%>
DROP INDEX <%==SIM:Index.Name==%> ON [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>];
<%==SIM:Line(2)==%>
<%==SIM:EndIf==%>
<%==SIM:EndFor==%>
<%==SIM:EndIf==%>

<%==SIM:If:Element.IsRemoved==%>
DROP TABLE [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>];
<%==SIM:Line(2)==%>
<%==SIM:EndIf==%>


<%==SIM:If:Element.IsAdded==%>
CREATE TABLE [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>]<%==SIM:Line==%>
(<%==SIM:StartBlock==%><%==SIM:Line==%>

	<%==SIM:ForEach:Element.Attributes==%>
		[<%==SIM:Attribute.Name==%>] [<%==SIM:Attribute.TypeName==%>] 
		<%==SIM:If:Attribute.HasTypeLength==%>(<%==SIM:Attribute.TypeLength==%>) <%==SIM:EndIf==%> 
		<%==SIM:If:Attribute.HasCollation==%>COLLATE <%==SIM:Attribute.Collation==%> <%==SIM:EndIf==%> 
		<%==SIM:If:Attribute.IsNullable==%>NULL<%==SIM:EndIf==%>
		<%==SIM:IfNot:Attribute.IsNullable==%>NOT NULL<%==SIM:EndIf==%>
		<%==SIM:If:Attribute.IsAutoIncrement==%> <%==SIM:If:Attribute.HasDefaultIdentity==%>IDENTITY(1,1)<%==SIM:Else==%>IDENTITY(<%==SIM:Attribute.IdentitySeed==%>,<%==SIM:Attribute.IdentityIncrement==%>)<%==SIM:EndIf==%><%==SIM:EndIf==%>
		<%==SIM:If:Attribute.HasDefaultValue==%> CONSTRAINT DF_<%==SIM:Element.Name==%>_<%==SIM:Attribute.Name==%> DEFAULT <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>
		<%==SIM:IfNot:IsLastItem==%>,<%==SIM:Line==%><%==SIM:EndIf==%>		
	<%==SIM:EndFor==%>

	<%==SIM:If:Element.HasPrimaryKey==%>
	,<%==SIM:Line==%>
	CONSTRAINT <%==SIM:Element.PrimaryKeyName==%><%==SIM:Space==%> 
	PRIMARY KEY (
	<%==SIM:ForEach:Element.PrimaryKeys==%>
	<%==SIM:Key.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%>
	<%==SIM:EndFor==%>)
	<%==SIM:EndIf==%>	

	<%==SIM:EndBlock==%><%==SIM:Line==%>
);<%==SIM:Line(2)==%>
<%==SIM:EndIf==%>


<%==SIM:If:Or(Element.IsChanged,Element.Repository.IsChanged,Element.Folder.IsChanged)==%>
<%==SIM:If:IsChanged(Element,Name)==%>
EXEC sp_rename '[<%==SIM:Coalesce(Element.PreviousState.Schema,"dbo")==%>].[<%==SIM:Element.PreviousState.Name==%>]', '<%==SIM:Element.Name==%>';
<%==SIM:Line(2)==%>
<%==SIM:EndIf==%>


<%==SIM:If:IsChanged(Element,Schema)==%>
ALTER SCHEMA <%==SIM:Coalesce(Element.Schema,"dbo")==%> TRANSFER [<%==SIM:Coalesce(Element.PreviousState.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>];
<%==SIM:Line(2)==%>
<%==SIM:EndIf==%>


<%==SIM:Set:PrimaryKeyChanged=False==%>
<%==SIM:ForEach:Element.ChangedAttributes==%>
	<%==SIM:If:Or(Attribute.IsPrimaryKey,Attribute.PreviousState.IsPrimaryKey)==%>
		<%==SIM:Set:PrimaryKeyChanged=True==%>
	<%==SIM:EndIf==%>
<%==SIM:EndFor==%>

<%==SIM:If:And(Element.PreviousState.HasPrimaryKey,PrimaryKeyChanged)==%>
	ALTER TABLE [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>] DROP CONSTRAINT <%==SIM:Element.PrimaryKeyName==%>;
	<%==SIM:Line==%>
<%==SIM:EndIf==%>


<%==SIM:If:Element.HasAddedAttributes==%>
ALTER TABLE [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>]<%==SIM:Line==%>
ADD<%==SIM:StartBlock==%><%==SIM:Line==%>

<%==SIM:ForEach:Element.AddedAttributes==%>
	[<%==SIM:Attribute.Name==%>] [<%==SIM:Attribute.TypeName==%>] 
	<%==SIM:If:Attribute.HasTypeLength==%>(<%==SIM:Attribute.TypeLength==%>) <%==SIM:EndIf==%> 
	<%==SIM:If:Attribute.HasCollation==%>COLLATE <%==SIM:Attribute.Collation==%> <%==SIM:EndIf==%> 
	<%==SIM:If:Attribute.IsNullable==%>NULL<%==SIM:EndIf==%>
	<%==SIM:IfNot:Attribute.IsNullable==%>NOT NULL<%==SIM:EndIf==%>
	<%==SIM:If:Attribute.IsAutoIncrement==%> <%==SIM:If:Attribute.HasDefaultIdentity==%>IDENTITY(1,1)<%==SIM:Else==%>IDENTITY(<%==SIM:Attribute.IdentitySeed==%>,<%==SIM:Attribute.IdentityIncrement==%>)<%==SIM:EndIf==%><%==SIM:EndIf==%>
	<%==SIM:If:Attribute.HasDefaultValue==%> CONSTRAINT DF_<%==SIM:Element.Name==%>_<%==SIM:Attribute.Name==%> DEFAULT <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>
	<%==SIM:IfNot:IsLastItem==%>,<%==SIM:Line==%><%==SIM:EndIf==%>	
<%==SIM:EndFor==%>;

<%==SIM:EndBlock==%><%==SIM:Line==%>
<%==SIM:EndIf==%>

<%==SIM:EndIf==%>

<%==SIM:IfNot:Element.IsAdded==%>
<%==SIM:If:And(Element.HasPrimaryKey,Or(PrimaryKeyChanged, Not(Element.PreviousState.HasPrimaryKey)))==%>	
	ALTER TABLE [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>] ADD CONSTRAINT <%==SIM:Element.PrimaryKeyName==%> PRIMARY KEY (<%==SIM:ForEach:Element.PrimaryKeys==%><%==SIM:Key.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
	<%==SIM:Line==%>
<%==SIM:EndIf==%>
<%==SIM:EndIf==%>


<%==SIM:ForEach:Element.AttributeChanges==%>
<%==SIM:Set:Attribute=Change.Current==%>
<%==SIM:Set:OldAttribute=Change.Previous==%>
<%==SIM:IfNot:Eq(Attribute.Name,OldAttribute.Name)==%>
EXEC sp_rename '<%==SIM:Coalesce(Element.Schema,"dbo")==%>.<%==SIM:Element.Name==%>.<%==SIM:OldAttribute.Name==%>' , '<%==SIM:Attribute.Name==%>', 'COLUMN'<%==SIM:Line==%>
GO<%==SIM:Line==%>
<%==SIM:EndIf==%>
ALTER TABLE [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>]<%==SIM:Line==%>
	<%==SIM:Indent==%>
	ALTER COLUMN [<%==SIM:Attribute.Name==%>] [<%==SIM:Attribute.TypeName==%>] 
	<%==SIM:If:Attribute.HasTypeLength==%>(<%==SIM:Attribute.TypeLength==%>) <%==SIM:EndIf==%>
	<%==SIM:If:Attribute.HasCollation==%>COLLATE <%==SIM:Attribute.Collation==%> <%==SIM:EndIf==%> 
	<%==SIM:If:Attribute.IsNullable==%>NULL<%==SIM:EndIf==%>
	<%==SIM:IfNot:Attribute.IsNullable==%>NOT NULL<%==SIM:EndIf==%>
	<%==SIM:If:Attribute.IsAutoIncrement==%> <%==SIM:If:Attribute.HasDefaultIdentity==%>IDENTITY(1,1)<%==SIM:Else==%>IDENTITY(<%==SIM:Attribute.IdentitySeed==%>,<%==SIM:Attribute.IdentityIncrement==%>)<%==SIM:EndIf==%><%==SIM:EndIf==%>
	<%==SIM:If:Attribute.HasDefaultValue==%> CONSTRAINT DF_<%==SIM:Element.Name==%>_<%==SIM:Attribute.Name==%> DEFAULT <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>
	<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.RemovedAttributes==%>
ALTER TABLE [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>]<%==SIM:Line==%>
	<%==SIM:Indent==%>
	DROP COLUMN [<%==SIM:Attribute.Name==%>] 
<%==SIM:Line==%>

<%==SIM:EndFor==%>
<%==SIM:EndIf==%>


<%==SIM:ForEach:Element.Attributes==%>
<%==SIM:If:IsAdded(Attribute, Description)==%>
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'<%==SIM:Attribute.Description==%>', @level0type=N'SCHEMA',@level0name=N'<%==SIM:Coalesce(Element.Schema,"dbo")==%>', @level1type=N'TABLE',@level1name=N'<%==SIM:Element.Name==%>', @level2type=N'COLUMN',@level2name=N'<%==SIM:Attribute.Name==%>'<%==SIM:Line==%>
GO<%==SIM:Line==%>
<%==SIM:EndIf==%>
<%==SIM:If:IsRemoved(Attribute, Description)==%>
EXEC sys.sp_dropextendedproperty @name=N'MS_Description', @level0type=N'SCHEMA',@level0name=N'<%==SIM:Coalesce(Element.Schema,"dbo")==%>', @level1type=N'TABLE',@level1name=N'<%==SIM:Element.Name==%>', @level2type=N'COLUMN',@level2name=N'<%==SIM:Attribute.Name==%>'<%==SIM:Line==%>
GO<%==SIM:Line==%>
<%==SIM:EndIf==%>
<%==SIM:If:IsChanged(Attribute, Description)==%>
EXEC sys.sp_updateextendedproperty @name=N'MS_Description', @value=N'<%==SIM:Attribute.Description==%>', @level0type=N'SCHEMA',@level0name=N'<%==SIM:Coalesce(Element.Schema,"dbo")==%>', @level1type=N'TABLE',@level1name=N'<%==SIM:Element.Name==%>', @level2type=N'COLUMN',@level2name=N'<%==SIM:Attribute.Name==%>'<%==SIM:Line==%>
GO<%==SIM:Line==%>
<%==SIM:EndIf==%>
<%==SIM:EndIf==%><%==SIM:EndFor==%>


<%==SIM:If:IsAdded(Element, Description)==%>
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'<%==SIM:Coalesce(Element.Description,Element.GetTaggedValue(Description))==%>' , @level0type=N'SCHEMA',@level0name=N'<%==SIM:Coalesce(Element.Schema,"dbo")==%>', @level1type=N'TABLE',@level1name=N'<%==SIM:Element.Name==%>'
<%==SIM:Line==%>
GO<%==SIM:Line==%>
<%==SIM:EndIf==%>

<%==SIM:If:IsRemoved(Element, Description)==%>
EXEC sys.sp_dropextendedproperty @name=N'MS_Description', @level0type=N'SCHEMA',@level0name=N'<%==SIM:Element.Coalesce(Element.Schema,"dbo")==%>', @level1type=N'TABLE',@level1name=N'<%==SIM:Element.Name==%>'
<%==SIM:Line==%>
<%==SIM:Line==%>
GO<%==SIM:Line==%>
<%==SIM:EndIf==%>

<%==SIM:If:IsChanged(Element, Description)==%>
EXEC sys.sp_updateextendedproperty @name=N'MS_Description', @value=N'<%==SIM:Coalesce(Element.Description,Element.GetTaggedValue(Description))==%>' , @level0type=N'SCHEMA',@level0name=N'<%==SIM:Coalesce(Element.Schema,"dbo")==%>', @level1type=N'TABLE',@level1name=N'<%==SIM:Element.Name==%>'
<%==SIM:Line==%>
GO<%==SIM:Line==%>
<%==SIM:EndIf==%>


<%==SIM:IfNot:Element.Indexes.IsEmpty==%>
-- Create indexes of table <%==SIM:Element.Name==%> ------------------------------<%==SIM:Line==%>
<%==SIM:ForEach(Index):Element.Indexes==%>
CREATE <%==SIM:If:Index.IsUnique==%>UNIQUE<%==SIM:EndIf==%><%==SIM:IfNot:Index.IsUnique==%>NONCLUSTERED<%==SIM:EndIf==%> INDEX <%==SIM:Index.Name==%> ON [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>]
<%==SIM:Line==%>
(<%==SIM:ForEach:Index.KeyAttributes==%>	
	<%==SIM:IndexAttribute.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>		
) 
<%==SIM:If:GT(Index.NonKeyAttributes.Count,0)==%>	
INCLUDE (<%==SIM:ForEach:Index.NonKeyAttributes==%>	
	<%==SIM:IndexAttribute.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>		
)
<%==SIM:EndIf==%> WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY];
<%==SIM:Line(2)==%>
<%==SIM:EndFor==%>

GO<%==SIM:Line==%><%==SIM:Line==%>
<%==SIM:EndIf==%>


<%==SIM:IfNot:Element.DataRows.IsEmpty==%>
-- Data of table <%==SIM:Element.Name==%> ------------------------------<%==SIM:Line==%>
<%==SIM:ForEach:Element.RemovedDataRows==%>
DELETE FROM [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>]  <%==SIM:Line==%>
WHERE <%==SIM:ForEach:Element.PrimaryKeys==%>[<%==SIM:Key.Name==%>] = '<%==SIM:DataRow.GetValue(Key)==%>'<%==SIM:IfNot:IsLastItem==%> AND <%==SIM:EndIf==%><%==SIM:EndFor==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.AddedDataRows==%>
INSERT INTO [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>] (<%==SIM:ForEach:Element.Attributes==%>[<%==SIM:Attribute.Name==%>]<%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>) <%==SIM:Line==%>
VALUES (<%==SIM:ForEach:DataRow.Values==%>'<%==SIM:Value==%>'<%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>); <%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:ForEach:Element.ChangedDataRows==%>
UPDATE [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>]  <%==SIM:Line==%>
SET <%==SIM:ForEach:Element.NonPrimaryKeys==%>[<%==SIM:Attribute.Name==%>] = '<%==SIM:DataRow.GetValue(Attribute)==%>' <%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%> <%==SIM:Line==%>
WHERE <%==SIM:ForEach:Element.PrimaryKeys==%>[<%==SIM:Key.Name==%>] = '<%==SIM:DataRow.GetValue(Key)==%>'<%==SIM:IfNot:IsLastItem==%> AND <%==SIM:EndIf==%><%==SIM:EndFor==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%>

<%==SIM:EndIf==%>