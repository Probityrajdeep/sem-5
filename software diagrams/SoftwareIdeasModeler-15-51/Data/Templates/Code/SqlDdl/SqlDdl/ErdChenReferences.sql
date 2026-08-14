<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:If:GreaterThan(Element.Relationships.Count,0)==%>
-- References for <%==SIM:Element.Name==%> --------------------------<%==SIM:Line==%>
ALTER TABLE <%==SIM:Coalesce(Element.Schema,"dbo")==%>.<%==SIM:Element.Name==%><%==SIM:Line==%>
ADD<%==SIM:Space==%><%==SIM:Line==%>
<%==SIM:ForEach:Element.Relationships==%>
	<%==SIM:Space(4)==%>CONSTRAINT <%==SIM:IfNot:IsEmpty(Relationship.Name)==%><%==SIM:Relationship.Name==%><%==SIM:EndIf==%><%==SIM:If:IsEmpty(Relationship.Name)==%>FK_<%==SIM:Element.Name==%>_<%==SIM:Relationship.Uid==%><%==SIM:EndIf==%> FOREIGN KEY (<%==SIM:ForEach:Relationship.ToEntity.Keys==%><%==SIM:Key.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>) REFERENCES <%==SIM:Coalesce(Relationship.FromEntity.Schema,"dbo")==%>.<%==SIM:Relationship.FromEntity.Name==%> (<%==SIM:ForEach:Relationship.FromEntity.Keys==%><%==SIM:Key.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
<%==SIM:IfNot:IsLastItem==%>, <%==SIM:Line==%><%==SIM:EndIf==%>
<%==SIM:EndFor==%>;
<%==SIM:Line==%>

<%==SIM:EndIf==%>