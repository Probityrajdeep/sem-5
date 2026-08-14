<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:UserInput:IndentationSize=Number("Indentation size",4)==%>
<%==SIM:UserInput:IndentationChar=Choice("Indentation char",Space,Tab)==%>
<%==SIM:If:Eq(IndentationChar,"Tab")==%><%==SIM:SetTabIndent==%><%==SIM:Else==%><%==SIM:SetSpaceIndent==%><%==SIM:EndIf==%><%==SIM:IndentSize(IndentationSize)==%>

<%==SIM:IfNot:Element.IsContained==%>
<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package=package==%>
<%==SIM:Set:public=public==%>

/**<%==SIM:Line==%>
<%==SIM:ForEach:Element.DocumentationLines==%>
 *<%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:If:Element.HasInterfaces==%>
    <%==SIM:ForEach:Element.Interfaces==%>
  * @implements {<%==SIM:Interface.Name==%>}<%==SIM:Line==%>
    <%==SIM:EndFor==%>
<%==SIM:EndIf==%>
*/<%==SIM:Line==%>
    
class <%==SIM:Element.Name==%>

<%==SIM:If:Element.HasSuperClass==%> extends <%==SIM:Element.SuperClass.Name==%><%==SIM:EndIf==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>        

    <%==SIM:ForEach:Element.AllAttributes ==%>            
        <%==SIM:IfNot:Or(Attribute.HasStereotype("property"), Attribute.HasStereotype("event"))==%>
        /**<%==SIM:Line==%>
        <%==SIM:ForEach:Attribute.DocumentationLines==%>
         *<%==SIM:DocumentationLine==%><%==SIM:Line==%>
        <%==SIM:EndFor==%>
         * @<%==SIM:Attribute.Visibility==%> <%==SIM:If:Attribute.IsReadOnly==%>@readonly<%==SIM:EndIf==%> @type {<%==SIM:Attribute.Type==%><%==SIM:If:Attribute.IsArray==%>[]<%==SIM:EndIf==%>}<%==SIM:Line==%>
         */<%==SIM:Line==%>
        <%==SIM:If:Attribute.IsStatic==%>static <%==SIM:EndIf==%><%==SIM:Attribute.Name==%>; 
        <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>            
        <%==SIM:EndIf==%>
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

            constructor (<%==SIM:ForEach:Constructor.Parameters==%><%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
            <%==SIM:Line==%>
                               
            {<%==SIM:StartBlock==%><%==SIM:Line==%>
                <%==SIM:If:Element.HasSuperClass==%>super();<%==SIM:EndIf==%>
                <%==SIM:ForEach:Element.AllAttributes==%>                                        
                    this.<%==SIM:Attribute.Visibility==%><%==SIM:Attribute.Name==%> = <%==SIM:If:Attribute.HasDefaultValue==%><%==SIM:Attribute.DefaultValue==%><%==SIM:Else==%>null<%==SIM:EndIf==%>;
                    <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
                <%==SIM:EndFor==%>

                <%==SIM:Constructor.SourceCodeBody==%>
            
            <%==SIM:EndBlock==%><%==SIM:Line==%>
            }<%==SIM:Line(2)==%>            
    
        <%==SIM:EndFor==%>
        <%==SIM:Line(1)==%>
    <%==SIM:EndIf==%>

    <%==SIM:ForEach:Element.AllAttributes==%>
        <%==SIM:If:Attribute.HasStereotype("property")==%>
            /**<%==SIM:Line==%>
            <%==SIM:ForEach:Attribute.DocumentationLines==%>
              * <%==SIM:DocumentationLine==%><%==SIM:Line==%>
            <%==SIM:EndFor==%>                  
              * @<%==SIM:Attribute.Visibility==%> @returns {<%==SIM:Attribute.Type==%><%==SIM:If:Attribute.IsArray==%>[]<%==SIM:EndIf==%>}<%==SIM:Line==%>
              */<%==SIM:Line==%>
            <%==SIM:If:Attribute.IsStatic==%>static <%==SIM:EndIf==%>get <%==SIM:Attribute.Name==%>()<%==SIM:Line==%>
            {<%==SIM:StartBlock==%><%==SIM:Line==%>
                <%==SIM:Attribute.GetBody==%>
            <%==SIM:EndBlock==%><%==SIM:Line==%>
            }<%==SIM:Line==%>
            <%==SIM:IfNot:Attribute.IsReadOnly==%>
            /**<%==SIM:Line==%>
            <%==SIM:ForEach:Attribute.DocumentationLines==%>
              * <%==SIM:DocumentationLine==%><%==SIM:Line==%>
            <%==SIM:EndFor==%>
              * @<%==SIM:Attribute.Visibility==%> @param {<%==SIM:Attribute.Type==%><%==SIM:If:Attribute.IsArray==%>[]<%==SIM:EndIf==%>} value<%==SIM:Line==%>
              */<%==SIM:Line==%>
            <%==SIM:If:Attribute.IsStatic==%>static <%==SIM:EndIf==%>set <%==SIM:Attribute.Name==%>(value)<%==SIM:Line==%>
            {<%==SIM:StartBlock==%><%==SIM:Line==%>
                <%==SIM:Attribute.SetBody==%>
            <%==SIM:EndBlock==%><%==SIM:Line==%>
            }<%==SIM:Line==%>            
            <%==SIM:EndIf==%><%==SIM:Line==%>
            <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>

        <%==SIM:EndIf==%>
    <%==SIM:EndFor==%>

    <%==SIM:ForEach:Element.Operations==%>            
        <%==SIM:Line==%>        
        /**<%==SIM:Line==%><%==SIM:ForEach:Operation.DocumentationLines==%>
          *<%==SIM:DocumentationLine==%><%==SIM:Line==%><%==SIM:EndFor==%><%==SIM:ForEach:Operation.Parameters==%>
          * @param {<%==SIM:Parameter.Type==%>} <%==SIM:Parameter.Name==%> <%==SIM:ToSingleLine(Parameter.Documentation)==%><%==SIM:Line==%>
        <%==SIM:EndFor==%>
          * @returns {<%==SIM:Operation.ReturnType==%>}<%==SIM:Line==%>
        */<%==SIM:Line==%>
        <%==SIM:If:Operation.IsStatic==%>static <%==SIM:EndIf==%><%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
        <%==SIM:Line==%>            
            {<%==SIM:StartBlock==%><%==SIM:Line==%>
                <%==SIM:Operation.SourceCodeBody==%>
            
            <%==SIM:EndBlock==%><%==SIM:Line==%>
            }
            <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>                

    <%==SIM:EndFor==%>
            

<%==SIM:EndBlock==%><%==SIM:Line==%>
}
<%==SIM:Line==%>