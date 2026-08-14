<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:If:GreaterThan(Element.Relationships.Count,0)==%>
-- References for <%==SIM:Element.Name==%> --------------------------<%==SIM:Line==%>
ALTER TABLE [<%==SIM:Coalesce(Element.Schema,"dbo")==%>].[<%==SIM:Element.Name==%>]<%==SIM:Line==%>
ADD<%==SIM:Space==%><%==SIM:Line==%>

<%==SIM:Line==%>

<%==SIM:EndIf==%>