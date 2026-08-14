<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>
<%==SIM:UserInput:IndentationSize=Number("Indentation size",4)==%>
<%==SIM:UserInput:IndentationChar=Choice("Indentation char",Space,Tab)==%>
<%==SIM:If:Eq(IndentationChar,"Tab")==%><%==SIM:SetTabIndent==%><%==SIM:Else==%><%==SIM:SetSpaceIndent==%><%==SIM:EndIf==%><%==SIM:IndentSize(IndentationSize)==%>

-- Table <%==SIM:Element.Name==%> --------------------------<%==SIM:Line==%>
<%==SIM:ForEach:Element.DocumentationLines==%>
	--<%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>

CREATE TABLE <%==SIM:Coalesce(Element.Schema,"dbo")==%>.<%==SIM:Element.Name==%><%==SIM:Line==%>
(<%==SIM:StartBlock==%><%==SIM:Line==%>

<%==SIM:ForEach:Element.Attributes==%>
	<%==SIM:Attribute.Name==%> nvarchar(MAX) NULL
<%==SIM:IfNot:IsLastItem==%>,<%==SIM:Line==%><%==SIM:EndIf==%>
<%==SIM:EndFor==%>

<%==SIM:If:Element.HasKey==%>
	,<%==SIM:Line==%>
	CONSTRAINT <%==SIM:Element.PrimaryKeyName==%><%==SIM:Space==%> 
	PRIMARY KEY (<%==SIM:ForEach:Element.Keys==%>
<%==SIM:Key.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%>
	<%==SIM:EndFor==%>)	
<%==SIM:EndIf==%>

<%==SIM:EndBlock==%><%==SIM:Line==%>
);<%==SIM:Line==%>
<%==SIM:EndIf==%>

