<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:If:GreaterThan(Element.References.Count,0)==%>
-- References for <%==SIM:Element.Name==%> --------------------------<%==SIM:Line==%>
<%==SIM:ForEach:Element.References==%>
ALTER TABLE <%==SIM:IfNot:IsBlank(Element.Schema)==%><%==SIM:Element.Schema==%>.<%==SIM:EndIf==%><%==SIM:Element.Name==%><%==SIM:Line==%>
ADD CONSTRAINT <%==SIM:IfNot:IsBlank(Reference.Name)==%><%==SIM:Reference.Name==%><%==SIM:EndIf==%><%==SIM:If:IsBlank(Reference.Name)==%>FK_<%==SIM:Element.Name==%>_<%==SIM:Reference.Uid==%><%==SIM:EndIf==%> FOREIGN KEY (<%==SIM:ForEach:Reference.ForeignKeyAttributes==%><%==SIM:Attribute.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>) REFERENCES <%==SIM:IfNot:IsBlank(Reference.PrimaryKeyEntity.Schema)==%><%==SIM:Reference.PrimaryKeyEntity.Schema==%>.<%==SIM:EndIf==%><%==SIM:Reference.PrimaryKeyEntity.Name==%> (<%==SIM:ForEach:Reference.PrimaryKeyAttributes==%><%==SIM:Attribute.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);
<%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:Line==%>

<%==SIM:EndIf==%>