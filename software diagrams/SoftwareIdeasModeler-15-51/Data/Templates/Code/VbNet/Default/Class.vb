<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:UserInput:IndentationSize=Number("Indentation size",4)==%>
<%==SIM:UserInput:IndentationChar=Choice("Indentation char",Space,Tab)==%>
<%==SIM:If:Eq(IndentationChar,"Tab")==%><%==SIM:SetTabIndent==%><%==SIM:Else==%><%==SIM:SetSpaceIndent==%><%==SIM:EndIf==%><%==SIM:IndentSize(IndentationSize)==%>

<%==SIM:IfNot:Element.IsContained==%>
<%==SIM:Set:private=Private==%>
<%==SIM:Set:protected=Protected==%>
<%==SIM:Set:package=Friend==%>
<%==SIM:Set:public=Public==%>

<%==SIM:ForEach:Imports==%>
    Imports <%==SIM:Import.Name==%>
    <%==SIM:Line==%>
<%==SIM:EndFor==%>

Namespace <%==SIM:Element.Namespace==%>
<%==SIM:StartBlock==%><%==SIM:Line==%>

    <%==SIM:ForEach:Element.DocumentationLines==%>
    '<%==SIM:DocumentationLine==%>
    <%==SIM:Line==%>
    <%==SIM:EndFor==%>

    <%==SIM:Element.Visibility==%> <%==SIM:If:Element.IsLeaf==%>NotInheritable <%==SIM:EndIf==%><%==SIM:If:Element.IsAbstract==%>MustInherit <%==SIM:EndIf==%>Class <%==SIM:Element.Name==%>
    <%==SIM:StartBlock==%><%==SIM:Line==%>

        <%==SIM:If:Element.HasSuperClass==%>
            Inherits <%==SIM:Element.SuperClass.Name==%>
            <%==SIM:Line==%>
        <%==SIM:EndIf==%>        

        <%==SIM:If:Element.HasInterfaces==%>
            Implements <%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>
            <%==SIM:Line==%>
        <%==SIM:EndIf==%>

        <%==SIM:Line==%>

        <%==SIM:ForEach:Element.NestedClasses==%>
            <%==SIM:Include(NestedClass.vb,NestedClass,False)==%>
        <%==SIM:EndFor==%>

        <%==SIM:ForEach:Element.AllAttributes==%>
            <%==SIM:IfNot:Attribute.HasStereotype("property")==%>
                <%==SIM:ForEach:Attribute.DocumentationLines==%>
    '<%==SIM:DocumentationLine==%>
                    <%==SIM:Line==%>
                <%==SIM:EndFor==%>

                <%==SIM:If:Equals(Attribute.Visibility,"")==%>Dim<%==SIM:EndIf==%><%==SIM:Attribute.Visibility==%> <%==SIM:Attribute.Name==%><%==SIM:If:Attribute.IsArray==%>()<%==SIM:EndIf==%> As <%==SIM:Attribute.Type==%><%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>
                <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
            <%==SIM:EndIf==%>
        <%==SIM:EndFor==%>
        <%==SIM:Line==%>


        <%==SIM:ForEach:Element.AllAttributes==%>            
            <%==SIM:If:Attribute.HasStereotype("property")==%>
                <%==SIM:ForEach:Attribute.DocumentationLines==%>
    '<%==SIM:DocumentationLine==%>
                    <%==SIM:Line==%>
                <%==SIM:EndFor==%>

                <%==SIM:If:And(IsEmpty(Attribute.GetBody),IsEmpty(Attribute.SetBody))==%>
                    <%==SIM:Attribute.Visibility==%><%==SIM:If:Attribute.IsStatic==%> Shared<%==SIM:EndIf==%> Property <%==SIM:Attribute.Name==%> As <%==SIM:Attribute.Type==%><%==SIM:If:Attribute.IsArray==%>()<%==SIM:EndIf==%> <%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>
                    <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
                <%==SIM:Else==%>
                    <%==SIM:Attribute.Visibility==%><%==SIM:If:Attribute.IsStatic==%> Shared<%==SIM:EndIf==%> Property <%==SIM:Attribute.Name==%> As <%==SIM:Attribute.Type==%><%==SIM:If:Attribute.IsArray==%>()<%==SIM:EndIf==%> 
                    <%==SIM:StartBlock==%><%==SIM:Line==%>
                        Get<%==SIM:StartBlock==%><%==SIM:Line==%>
                            <%==SIM:Attribute.GetBody==%>
                        <%==SIM:EndBlock==%><%==SIM:Line==%>
                        End Get<%==SIM:Line==%>
                        Set(ByVal value As <%==SIM:Attribute.Type==%><%==SIM:If:Attribute.IsArray==%>()<%==SIM:EndIf==%>)
                        <%==SIM:StartBlock==%><%==SIM:Line==%>
                            <%==SIM:Attribute.SetBody==%>
                        <%==SIM:EndBlock==%><%==SIM:Line==%>
                        End Set<%==SIM:Line==%>
                    <%==SIM:EndBlock==%><%==SIM:Line==%>
                    End Property<%==SIM:Line==%>
                    <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
                <%==SIM:EndIf==%>
            <%==SIM:EndIf==%>
        <%==SIM:EndFor==%>


        <%==SIM:If:Element.HasAttributes==%><%==SIM:If:Element.HasOperations==%><%==SIM:Line(2)==%><%==SIM:EndIf==%><%==SIM:EndIf==%>


        <%==SIM:ForEach:Element.Constructors==%>
        <%==SIM:Line==%>
        <%==SIM:If:Or(Constructor.HasDocumentation, Constructor.HasNestedDocumentation)==%>
        ''' <summary>
        <%==SIM:Line==%><%==SIM:ForEach:Constructor.DocumentationLines==%>
        '''<%==SIM:DocumentationLine==%><%==SIM:Line==%><%==SIM:EndFor==%>
        ''' </summary><%==SIM:ForEach:Constructor.Parameters==%>
        ''' <param name="<%==SIM:Parameter.Name==%>"> <%==SIM:ToSingleLine(Parameter.Documentation)==%></param><%==SIM:Line==%>
        <%==SIM:EndFor==%><%==SIM:Line==%>
        <%==SIM:EndIf==%>

        <%==SIM:Constructor.Visibility==%><%==SIM:If:Constructor.IsStatic==%> Shared<%==SIM:EndIf==%> Sub New (<%==SIM:ForEach:Constructor.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:If:Constructor.IsAbstract==%>;<%==SIM:EndIf==%>
        <%==SIM:Line==%>

        <%==SIM:StartBlock==%><%==SIM:Line==%>
        <%==SIM:Constructor.SourceCodeBody==%>

        <%==SIM:EndBlock==%><%==SIM:Line==%>
        End Sub
        <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>

        <%==SIM:EndFor==%>
        <%==SIM:Line(1)==%>
          
          

        <%==SIM:ForEach:Element.Operations==%>
            <%==SIM:Line==%>
              
            <%==SIM:If:Or(Operation.HasDocumentation, Operationr.HasNestedDocumentation)==%>
            ''' <summary>
            <%==SIM:Line==%><%==SIM:ForEach:Operation.DocumentationLines==%>
            '''<%==SIM:DocumentationLine==%><%==SIM:Line==%><%==SIM:EndFor==%>
            '''</summary><%==SIM:ForEach:Operation.Parameters==%>
            ''' <param name="<%==SIM:Parameter.Name==%>"> <%==SIM:ToSingleLine(Parameter.Documentation)==%></param><%==SIM:Line==%>
            <%==SIM:EndFor==%><%==SIM:Line==%>
            <%==SIM:EndIf==%>

            <%==SIM:Operation.Visibility==%><%==SIM:If:Operation.IsStatic==%> Shared<%==SIM:EndIf==%><%==SIM:If:Operation.IsOverride==%> Overrides<%==SIM:EndIf==%><%==SIM:If:Operation.IsVirtual==%> Overridable<%==SIM:EndIf==%><%==SIM:If:Operation.IsAbstract==%> MustOverride<%==SIM:EndIf==%> <%==SIM:If:Operation.HasReturnType==%>Function<%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>Sub<%==SIM:EndIf==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%> As <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>) <%==SIM:If:Operation.HasReturnType==%>As <%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%>
            <%==SIM:Line==%>
                <%==SIM:Operation.SourceCodeBody==%>
                <%==SIM:Line==%>
            End <%==SIM:If:Operation.HasReturnType==%>Function<%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>Sub<%==SIM:EndIf==%>

            <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>

        <%==SIM:EndFor==%>

        <%==SIM:Line==%>
    <%==SIM:EndBlock==%><%==SIM:Line==%>
    End Class

<%==SIM:EndBlock==%><%==SIM:Line==%>
End Namespace
<%==SIM:Line==%>
<%==SIM:EndIf==%>