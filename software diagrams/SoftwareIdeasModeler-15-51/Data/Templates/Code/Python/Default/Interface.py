<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>
<%==SIM:UserInput:IndentationSize=Number("Indentation size",4)==%>
<%==SIM:UserInput:IndentationChar=Choice("Indentation char",Space,Tab)==%>
<%==SIM:If:Eq(IndentationChar,"Tab")==%><%==SIM:SetTabIndent==%><%==SIM:Else==%><%==SIM:SetSpaceIndent==%><%==SIM:EndIf==%><%==SIM:IndentSize(IndentationSize)==%>
<%==SIM:Set:private=__==%><%==SIM:Set:protected===%><%==SIM:Set:package===%><%==SIM:Set:public===%>

<%==SIM:ForEach:Element.DocumentationLines==%>#<%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>
class <%==SIM:Element.Name==%><%==SIM:If:Element.HasSuperClassOrInterface==%>(<%==SIM:ForEach:Element.SuperClasses==%><%==SIM:SuperClass.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:If:Element.HasSuperClass==%>,<%==SIM:EndIf==%> <%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:EndIf==%>:
<%==SIM:StartBlock==%><%==SIM:Line==%>
<%==SIM:ForEach:Element.AllAttributes==%><%==SIM:If:Attribute.IsStatic==%>    
	
	<%==SIM:ForEach:Attribute.DocumentationLines==%>
	#<%==SIM:DocumentationLine==%><%==SIM:Line==%>
    <%==SIM:EndFor==%>
	
	<%==SIM:Attribute.Visibility==%><%==SIM:Attribute.Name==%> = <%==SIM:If:Attribute.HasDefaultValue==%><%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%><%==SIM:IfNot:Attribute.HasDefaultValue==%><%==SIM:If:Attribute.OriginalType.HasClassifier==%><%==SIM:Attribute.OriginalType.Classifier.Name==%>()<%==SIM:ElseIf:Attribute.OriginalType.IsString==%>""<%==SIM:ElseIf:Attribute.OriginalType.IsNumber==%>0<%==SIM:ElseIf:Attribute.OriginalType.IsBoolean==%>False<%==SIM:Else==%>None<%==SIM:EndIf==%><%==SIM:EndIf==%>
	<%==SIM:Line==%>

    assert(type(<%==SIM:Attribute.Visibility==%><%==SIM:Attribute.Name==%>)==<%==SIM:Attribute.Type==%>)
	<%==SIM:Line(2)==%>
<%==SIM:EndIf==%><%==SIM:EndFor==%>

    <%==SIM:Set:Constructor=Element.Constructors.First==%>
	def __init__(self<%==SIM:ForEach:Constructor.Parameters==%>, <%==SIM:Parameter.Name==%><%==SIM:EndFor==%>):	
	<%==SIM:StartBlock==%><%==SIM:Line==%>

	<%==SIM:ForEach:Element.AllAttributes==%><%==SIM:IfNot:Attribute.IsStatic==%>
            <%==SIM:IfNot:Attribute.HasStereotype("property")==%>
			    <%==SIM:ForEach:Attribute.DocumentationLines==%>
			    #<%==SIM:DocumentationLine==%><%==SIM:Line==%>	
			    <%==SIM:EndFor==%>
            <%==SIM:EndIf==%>

            <%==SIM:Set:Assignment===%>
            <%==SIM:ForEach:Constructor.Parameters==%>
            <%==SIM:If:Eq(Parameter.Name,Attribute.Name)==%>
            <%==SIM:Set:Assignment=Parameter.Name==%>
            <%==SIM:EndIf==%>
            <%==SIM:EndFor==%>


			self.<%==SIM:Attribute.Visibility==%><%==SIM:Attribute.Name==%> = <%==SIM:IfNot:IsEmpty(Assignment)==%><%==SIM:Assignment==%><%==SIM:Else==%><%==SIM:If:Attribute.HasDefaultValue==%><%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%><%==SIM:IfNot:Attribute.HasDefaultValue==%><%==SIM:If:Attribute.OriginalType.HasClassifier==%><%==SIM:Attribute.OriginalType.Classifier.Name==%>()<%==SIM:ElseIf:Attribute.OriginalType.IsString==%>""<%==SIM:ElseIf:Attribute.OriginalType.IsNumber==%>0<%==SIM:ElseIf:Attribute.OriginalType.IsBoolean==%>False<%==SIM:Else==%>None<%==SIM:EndIf==%><%==SIM:EndIf==%><%==SIM:EndIf==%>    
			<%==SIM:Line==%>
	<%==SIM:EndIf==%><%==SIM:EndFor==%>
	<%==SIM:EndBlock==%>
	<%==SIM:Line==%>

	<%==SIM:ForEach:Element.AllAttributes==%>
        <%==SIM:If:Attribute.HasStereotype("property")==%>
            <%==SIM:ForEach:Attribute.DocumentationLines==%>
                #<%==SIM:DocumentationLine==%>
                <%==SIM:Line==%>
            <%==SIM:EndFor==%>

            @property<%==SIM:Line==%>
            def <%==SIM:Attribute.Name==%>(self):
            <%==SIM:StartBlock==%><%==SIM:Line==%>
                <%==SIM:If:IsEmpty(Attribute.GetBody)==%>
                    return self.<%==SIM:Attribute.Visibility==%><%==SIM:Attribute.Name==%>;<%==SIM:Line==%>
                <%==SIM:Else==%>
                    <%==SIM:Attribute.GetBody==%>                    
                <%==SIM:EndIf==%>
            <%==SIM:EndBlock==%>
            <%==SIM:Line==%>

            @<%==SIM:Attribute.Name==%>.setter<%==SIM:Line==%>
            <%==SIM:IfNot:Attribute.IsReadOnly==%>
                def <%==SIM:Attribute.Name==%>(self, value):
                <%==SIM:StartBlock==%><%==SIM:Line==%>
                    <%==SIM:If:IsEmpty(Attribute.SetBody)==%>
                        self.<%==SIM:Attribute.Visibility==%><%==SIM:Attribute.Name==%> = value;
                    <%==SIM:Else==%>
                        <%==SIM:Attribute.GetBody==%>                    
                    <%==SIM:EndIf==%>
                <%==SIM:EndBlock==%>
            <%==SIM:EndIf==%>
            
            
            <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
            
        <%==SIM:EndIf==%>
    <%==SIM:EndFor==%>
    <%==SIM:Line==%>

	<%==SIM:ForEach:Element.Operations==%>    
	<%==SIM:ForEach:Operation.DocumentationLines==%>#<%==SIM:DocumentationLine==%><%==SIM:Line==%>
    <%==SIM:EndFor==%>
	def <%==SIM:Operation.Visibility==%><%==SIM:Operation.Name==%> (self<%==SIM:ForEach:Operation.Parameters==%>, <%==SIM:Parameter.Name==%><%==SIM:EndFor==%>):	
	<%==SIM:StartBlock==%><%==SIM:Line==%>
        <%==SIM:Line==%>		
		<%==SIM:EndBlock==%><%==SIM:Line==%>	


<%==SIM:EndFor==%>
<%==SIM:EndBlock==%>
