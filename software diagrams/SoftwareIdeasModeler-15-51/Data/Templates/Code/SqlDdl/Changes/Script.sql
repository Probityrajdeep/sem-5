<%==SIM:Set:private=Private==%><%==SIM:Set:protected=Protected==%><%==SIM:Set:package=Friend==%><%==SIM:Set:public=Public==%>
<%==SIM:ForEach:Diagram.Elements==%><%==SIM:If:Or(Element.OfType(idef1x-entity),Element.OfType(erd-entity),Element.OfType(class))==%>
-- Table <%==SIM:Element.Name==%> --------------------------
<%==SIM:ForEach:Element.DocumentationLines==%>--<%==SIM:DocumentationLine==%> 
<%==SIM:EndFor==%>
CREATE TABLE [<%==SIM:Element.Name==%>]
(
<%==SIM:ForEach:Element.Attributes==%>[<%==SIM:Attribute.Name==%>] [<%==SIM:Attribute.TypeName==%>] <%==SIM:If:Attribute.HasTypeLength==%>(<%==SIM:Attribute.TypeLength==%>)<%==SIM:EndIf==%> <%==SIM:If:Attribute.IsNullable==%>NULL<%==SIM:EndIf==%><%==SIM:IfNot:Attribute.IsNullable==%>NOT NULL<%==SIM:EndIf==%><%==SIM:If:Attribute.IsAutoIncrement==%> IDENTITY (1, 1)<%==SIM:EndIf==%><%==SIM:IfNot:IsLastItem==%>,<%==SIM:EndIf==%>
<%==SIM:EndFor==%><%==SIM:If:Element.HasPrimaryKey==%>,
CONSTRAINT PK_<%==SIM:Element.Name==%> PRIMARY KEY (<%==SIM:ForEach:Element.PrimaryKeys==%><%==SIM:Key.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:EndIf==%>
)<%==SIM:EndIf==%>

-- Indexes ------------------------------
<%==SIM:ForEach:Element.Indexes==%>
CREATE NONCLUSTERED INDEX <%==SIM:Index.Name==%> ON <%==SIM:Element.Name==%>
(<%==SIM:ForEach:Index.Attributes==%>
	<%==SIM:IndexAttribute.Name==%><%==SIM:IfNot:IsLastItem==%>,<%==SIM:EndIf==%><%==SIM:EndFor==%>	
) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
<%==SIM:EndFor==%>

<%==SIM:EndFor==%>

<%==SIM:ForEach:Diagram.Elements==%><%==SIM:If:Element.HasForeignKey==%><%==SIM:If:Or(Element.OfType(idef1x-entity),Element.OfType(erd-entity),Element.OfType(class))==%>
-- References for <%==SIM:Element.Name==%> --------------------------
ALTER TABLE [<%==SIM:Element.Name==%>]
ADD
<%==SIM:ForEach:Element.References==%>CONSTRAINT FK_<%==SIM:Element.Name==%>_<%==SIM:Reference.Name==%> FOREIGN KEY (<%==SIM:ForEach:Reference.ForeignKeyAttributes==%><%==SIM:Attribute.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>) REFERENCES <%==SIM:Reference.PrimaryKeyEntity.Name==%> (<%==SIM:ForEach:Reference.PrimaryKeyAttributes==%><%==SIM:Attribute.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
<%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>
<%==SIM:EndIf==%><%==SIM:EndIf==%>
<%==SIM:EndFor==%>