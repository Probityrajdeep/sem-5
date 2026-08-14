<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>
<%==SIM:UserInput:IndentationSize=Number("Indentation size",4)==%>
<%==SIM:UserInput:IndentationChar=Choice("Indentation char",Space,Tab)==%>
<%==SIM:If:Eq(IndentationChar,"Tab")==%><%==SIM:SetTabIndent==%><%==SIM:Else==%><%==SIM:SetSpaceIndent==%><%==SIM:EndIf==%><%==SIM:IndentSize(IndentationSize)==%>

-- Table <%==SIM:Element.Name==%> --------------------------<%==SIM:Line==%>
<%==SIM:ForEach:Element.DocumentationLines==%>
	--<%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:If:Or(Not(IsBlank(Element.Description)),Element.HasTaggedValue(Description))==%>
<%==SIM:Line==%>
/* <%==SIM:Coalesce(Element.Description,Element.GetTaggedValue(Description))==%> */
<%==SIM:Line==%>
<%==SIM:EndIf==%>

CREATE TABLE <%==SIM:IfNot:IsBlank(Element.Schema)==%><%==SIM:Element.Schema==%>.<%==SIM:EndIf==%><%==SIM:Element.Name==%><%==SIM:Line==%>
(<%==SIM:StartBlock==%><%==SIM:Line==%>

<%==SIM:ForEach:Element.Attributes==%>
	<%==SIM:Attribute.Name==%> <%==SIM:Attribute.TypeName==%> 
<%==SIM:If:Attribute.HasTypeLength==%>(<%==SIM:Attribute.TypeLength==%>) <%==SIM:EndIf==%> 
<%==SIM:If:Attribute.HasCollation==%>COLLATE <%==SIM:Attribute.Collation==%> <%==SIM:EndIf==%> 
<%==SIM:If:Attribute.IsNullable==%> NULL<%==SIM:EndIf==%>
<%==SIM:IfNot:Attribute.IsNullable==%> NOT NULL<%==SIM:EndIf==%>
<%==SIM:If:Attribute.IsAutoIncrement==%> <%==SIM:If:Attribute.HasDefaultIdentity==%>IDENTITY(1,1)<%==SIM:Else==%>IDENTITY(<%==SIM:Attribute.IdentitySeed==%>,<%==SIM:Attribute.IdentityIncrement==%>)<%==SIM:EndIf==%><%==SIM:EndIf==%>
<%==SIM:If:Attribute.HasDefaultValue==%> CONSTRAINT DF_<%==SIM:Element.Name==%>_<%==SIM:Attribute.Name==%> DEFAULT <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>
<%==SIM:IfNot:IsLastItem==%>,<%==SIM:EndIf==%>
<%==SIM:If:Attribute.HasDescription==%>  -- <%==SIM:Attribute.Description==%><%==SIM:EndIf==%>
<%==SIM:Line==%>

<%==SIM:EndFor==%>

<%==SIM:If:Element.HasPrimaryKey==%>
	,<%==SIM:Line==%>
	CONSTRAINT <%==SIM:Element.PrimaryKeyName==%><%==SIM:Space==%> 
	PRIMARY KEY (<%==SIM:ForEach:Element.PrimaryKeys==%>
<%==SIM:Key.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%>
	<%==SIM:EndFor==%>)	
<%==SIM:EndIf==%>

<%==SIM:EndBlock==%><%==SIM:Line==%>
);<%==SIM:Line==%>
<%==SIM:EndIf==%>
<%==SIM:Line(2)==%>


<%==SIM:IfNot:Element.Indexes.IsEmpty==%>
-- Indexes of table <%==SIM:Element.Name==%> ------------------------------<%==SIM:Line==%>
<%==SIM:ForEach:Element.Indexes==%>
CREATE <%==SIM:If:Index.IsUnique==%>UNIQUE<%==SIM:EndIf==%> INDEX <%==SIM:Index.Name==%> ON <%==SIM:IfNot:IsBlank(Element.Schema)==%><%==SIM:Element.Schema==%>.<%==SIM:EndIf==%><%==SIM:Element.Name==%><%==SIM:Line==%>
(
<%==SIM:ForEach:Index.Attributes==%>
	<%==SIM:IndexAttribute.Name==%><%==SIM:IfNot:IsLastItem==%>,<%==SIM:EndIf==%><%==SIM:EndFor==%>	
)<%==SIM:Line==%>
;
<%==SIM:EndFor==%>
<%==SIM:EndIf==%>


<%==SIM:IfNot:Element.DataRows.IsEmpty==%>
-- Data of table <%==SIM:Element.Name==%> ------------------------------<%==SIM:Line==%>
<%==SIM:If:Element.HasAutoIncrement==%>SET IDENTITY_INSERT <%==SIM:IfNot:IsBlank(Element.Schema)==%><%==SIM:Element.Schema==%>.<%==SIM:EndIf==%><%==SIM:Element.Name==%> ON
<%==SIM:Line==%>
<%==SIM:EndIf==%>
<%==SIM:ForEach:Element.DataRows==%>
INSERT INTO <%==SIM:IfNot:IsBlank(Element.Schema)==%><%==SIM:Element.Schema==%>.<%==SIM:EndIf==%><%==SIM:Element.Name==%> (<%==SIM:ForEach:Element.Attributes==%><%==SIM:Attribute.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
 VALUES (<%==SIM:ForEach:DataRow.Values==%>'<%==SIM:Value==%>'<%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
<%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:Line==%>
<%==SIM:If:Element.HasAutoIncrement==%>SET IDENTITY_INSERT <%==SIM:IfNot:IsBlank(Element.Schema)==%><%==SIM:Element.Schema==%>.<%==SIM:EndIf==%><%==SIM:Element.Name==%> OFF
<%==SIM:Line==%>
<%==SIM:EndIf==%>
<%==SIM:EndIf==%>
