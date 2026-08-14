<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:UserInput:IndentationSize=Number("Indentation size",4)==%>
<%==SIM:UserInput:IndentationChar=Choice("Indentation char",Space,Tab)==%>
<%==SIM:If:Eq(IndentationChar,"Tab")==%><%==SIM:SetTabIndent==%><%==SIM:Else==%><%==SIM:SetSpaceIndent==%><%==SIM:EndIf==%><%==SIM:IndentSize(IndentationSize)==%>

<%==SIM:IfNot:Element.IsContained==%>
<%==SIM:Set:private=#==%>
<%==SIM:Set:protected===%>
<%==SIM:Set:package===%>
<%==SIM:Set:public===%>

<%==SIM:ForEach:Element.DocumentationLines==%>
    //<%==SIM:DocumentationLine==%>
    <%==SIM:Line==%>
<%==SIM:EndFor==%>
    
    class <%==SIM:Element.Name==%>

    <%==SIM:If:Element.HasSuperClassOrInterface==%> extends <%==SIM:Element.SuperClass.Name==%><%==SIM:If:Element.HasInterfaces==%><%==SIM:If:Element.HasSuperClass==%>,<%==SIM:EndIf==%> <%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%><%==SIM:EndIf==%>
    <%==SIM:Line==%>
    {<%==SIM:StartBlock==%><%==SIM:Line==%>        

        <%==SIM:ForEach:Element.AllAttributes==%>            
            <%==SIM:ForEach:Attribute.DocumentationLines==%>
                //<%==SIM:DocumentationLine==%>
                <%==SIM:Line==%>
            <%==SIM:EndFor==%>

            <%==SIM:Attribute.Visibility==%><%==SIM:Attribute.Name==%>; /* <%==SIM:Attribute.Type==%><%==SIM:If:Attribute.IsArray==%>[]<%==SIM:EndIf==%> */
            <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>            
        <%==SIM:EndFor==%>

        <%==SIM:If:Element.HasAttributes==%><%==SIM:If:Element.HasOperations==%><%==SIM:Line(2)==%><%==SIM:EndIf==%><%==SIM:EndIf==%>

        <%==SIM:If:Element.HasConstructors==%>
            <%==SIM:ForEach:Element.Constructors==%>
                <%==SIM:Line==%>
                <%==SIM:If:Or(Constructor.HasDocumentation, Constructor.HasNestedDocumentation)==%>
                /**<%==SIM:Line==%><%==SIM:ForEach:Constructor.DocumentationLines==%>
                 *<%==SIM:DocumentationLine==%><%==SIM:Line==%><%==SIM:EndFor==%><%==SIM:ForEach:Constructor.Parameters==%>
                 * @param <%==SIM:Parameter.Name==%> <%==SIM:ToSingleLine(Parameter.Documentation)==%><%==SIM:Line==%>
                <%==SIM:EndFor==%>*/<%==SIM:Line==%>
                <%==SIM:EndIf==%>

                constructor (<%==SIM:ForEach:Constructor.Parameters==%>/*<%==SIM:Parameter.Type==%>*/ <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
                <%==SIM:Line==%>
                               
                    {<%==SIM:StartBlock==%><%==SIM:Line==%>
                        <%==SIM:ForEach:Element.AllAttributes==%>                                        
                            this.<%==SIM:Attribute.Visibility==%><%==SIM:Attribute.Name==%> = <%==SIM:If:Attribute.HasDefaultValue==%><%==SIM:Attribute.DefaultValue==%><%==SIM:Else==%>null<%==SIM:EndIf==%>;
                            <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
                        <%==SIM:EndFor==%>

                        <%==SIM:Constructor.SourceCodeBody==%>
            
                    <%==SIM:EndBlock==%><%==SIM:Line==%>
                    }
                    <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
    
            <%==SIM:EndFor==%>
            <%==SIM:Line(1)==%>
        <%==SIM:EndIf==%>
        <%==SIM:IfNot:Element.HasConstructors==%>
                constructor ()<%==SIM:Line==%>                               
                    {<%==SIM:StartBlock==%><%==SIM:Line==%>
                        <%==SIM:ForEach:Element.AllAttributes==%>                                        
                            this.<%==SIM:Attribute.Visibility==%><%==SIM:Attribute.Name==%> = <%==SIM:If:Attribute.HasDefaultValue==%><%==SIM:Attribute.DefaultValue==%><%==SIM:Else==%>null<%==SIM:EndIf==%>;
                            <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
                        <%==SIM:EndFor==%>
                                    
                    <%==SIM:EndBlock==%><%==SIM:Line==%>
                    }
                    <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
        <%==SIM:EndIf==%>

        <%==SIM:ForEach:Element.Operations==%>            
            <%==SIM:Line==%>
            <%==SIM:If:Or(Operation.HasDocumentation,Operation.HasNestedDocumentation)==%>
            /**<%==SIM:Line==%><%==SIM:ForEach:Operation.DocumentationLines==%>
                *<%==SIM:DocumentationLine==%><%==SIM:Line==%><%==SIM:EndFor==%><%==SIM:ForEach:Operation.Parameters==%>
                * @param <%==SIM:Parameter.Name==%> <%==SIM:ToSingleLine(Parameter.Documentation)==%><%==SIM:Line==%>
            <%==SIM:EndFor==%>*/<%==SIM:Line==%>
            <%==SIM:EndIf==%>

            <%==SIM:If:Operation.IsStatic==%>static <%==SIM:EndIf==%><%==SIM:If:Operation.HasReturnType==%>/*<%==SIM:Operation.ReturnType==%>*/ <%==SIM:EndIf==%><%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%>/*<%==SIM:Parameter.Type==%>*/ <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
            <%==SIM:Line==%>            
                {<%==SIM:StartBlock==%><%==SIM:Line==%>
                    <%==SIM:Operation.SourceCodeBody==%>
            
                <%==SIM:EndBlock==%><%==SIM:Line==%>
                }
                <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>                

        <%==SIM:EndFor==%>
            

    <%==SIM:EndBlock==%><%==SIM:Line==%>
    }

<%==SIM:EndBlock==%><%==SIM:Line==%>