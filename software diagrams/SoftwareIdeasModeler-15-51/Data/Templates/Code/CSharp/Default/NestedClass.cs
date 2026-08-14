<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:Set:private=private==%><%==SIM:Set:protected=protected==%><%==SIM:Set:package=internal==%><%==SIM:Set:public=public==%>

<%==SIM:UserInput:ArrayType=Choice("Array type",Array,IEnumerable,ICollection,IList,List)==%>
<%==SIM:UserInput:Documentation=YesNo("Documentation")==%>

<%==SIM:Template:TypeTemplate(Typable)==%>
<%==SIM:If:Or(Typable.IsArray,Typable.ReturnIsArray)==%>
<%==SIM:If:Typable.IsUnique==%><%==SIM:If:Typable.IsOrdered==%>SortedSet<<%==SIM:Typable.Type==%>><%==SIM:Else==%>HashSet<<%==SIM:Typable.Type==%>><%==SIM:EndIf==%>
<%==SIM:Else==%>
<%==SIM:If:Typable.IsOrdered==%><%==SIM:If:Or(Eq(ArrayType,"Array"), IsEmpty(ArrayType))==%><%==SIM:Typable.Type==%>[]<%==SIM:Else==%><%==SIM:ArrayType==%><<%==SIM:Typable.Type==%>><%==SIM:EndIf==%>
<%==SIM:Else==%>ConcurrentBag<<%==SIM:Typable.Type==%>><%==SIM:EndIf==%>
<%==SIM:EndIf==%>
<%==SIM:Else==%>
<%==SIM:Typable.Type==%>
<%==SIM:EndIf==%><%==SIM:Space(1)==%>
<%==SIM:EndTemplate==%>

<%==SIM:If:Documentation==%><%==SIM:If:Element.HasDocumentation==%>
    /// <summary><%==SIM:Line==%>
<%==SIM:ForEach:Element.SimpleHtmlDocumentationLines==%>
    /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>
    /// </summary><%==SIM:Line==%>
<%==SIM:EndIf==%><%==SIM:EndIf==%>

<%==SIM:IfNot:IsEmpty(Element.Visibility)==%><%==SIM:Element.Visibility==%> <%==SIM:EndIf==%><%==SIM:If:Element.IsStatic==%>static <%==SIM:EndIf==%><%==SIM:If:Element.IsLeaf==%>sealed <%==SIM:EndIf==%><%==SIM:If:Element.IsAbstract==%>abstract <%==SIM:EndIf==%>class <%==SIM:Element.Name==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>
        
    <%==SIM:ForEach:Element.NestedClasses==%>
        <%==SIM:Include(NestedClass.cs,NestedClass,False)==%>
    <%==SIM:EndFor==%>
    <%==SIM:ForEach:Element.InRelations==%>
        <%==SIM:If:And(Equals(Relation.ElementType,"containment"), Equals(Relation.From.ElementType,"enumeration"))==%>
            <%==SIM:Include(NestedEnum.cs, Relation.From, False)==%>
        <%==SIM:EndIf==%>
    <%==SIM:EndFor==%>

    <%==SIM:ForEach:Element.AllAttributes==%>
        <%==SIM:IfNot:Or(Attribute.HasStereotype("prop"), Attribute.HasStereotype("property"), Attribute.HasStereotype("event"))==%>
            <%==SIM:If:Documentation==%><%==SIM:If:Attribute.HasDocumentation==%>
            <%==SIM:ForEach:Attribute.SimpleHtmlDocumentationLines==%>
                //<%==SIM:DocumentationLine==%>
                <%==SIM:Line==%>
            <%==SIM:EndFor==%>
            <%==SIM:EndIf==%><%==SIM:EndIf==%>

            <%==SIM:ForEach:Attribute.TaggedValues("Annotation")==%>
            [<%==SIM:TaggedValue.Value==%>]<%==SIM:Line==%>
            <%==SIM:EndFor==%>

            <%==SIM:Attribute.Visibility==%><%==SIM:If:Attribute.IsStatic==%> static<%==SIM:EndIf==%><%==SIM:If:Attribute.IsReadOnly==%> readonly<%==SIM:EndIf==%> <%==SIM:TypeTemplate(Attribute)==%><%==SIM:Space==%>
            <%==SIM:Attribute.Name==%>
            <%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>;
            <%==SIM:Line==%>
        <%==SIM:EndIf==%>
    <%==SIM:EndFor==%>
    <%==SIM:Line==%>

    <%==SIM:ForEach:Element.AllAttributes==%>
        <%==SIM:If:Or(Attribute.HasStereotype("prop"), Attribute.HasStereotype("property"))==%>
            <%==SIM:If:Documentation==%><%==SIM:If:Attribute.HasDocumentation==%>
                /// <summary><%==SIM:Line==%>
            <%==SIM:ForEach:Attribute.SimpleHtmlDocumentationLines==%>
                /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
            <%==SIM:EndFor==%>
                /// </summary><%==SIM:Line==%>
            <%==SIM:EndIf==%><%==SIM:EndIf==%>

            <%==SIM:ForEach:Attribute.TaggedValues("Annotation")==%>
            [<%==SIM:TaggedValue.Value==%>]<%==SIM:Line==%>
            <%==SIM:EndFor==%>

            <%==SIM:If:And(IsEmpty(Attribute.GetBody), IsEmpty(Attribute.SetBody))==%>
                <%==SIM:Attribute.Visibility==%><%==SIM:If:Attribute.IsStatic==%> static<%==SIM:EndIf==%> <%==SIM:TypeTemplate(Attribute)==%><%==SIM:Space==%> <%==SIM:Attribute.Name==%>
                { get; <%==SIM:IfNot:Attribute.IsReadOnly==%>set;<%==SIM:EndIf==%> }<%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%>;<%==SIM:EndIf==%>
                <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
            <%==SIM:Else==%>
                <%==SIM:Attribute.Visibility==%><%==SIM:If:Attribute.IsStatic==%> static<%==SIM:EndIf==%> <%==SIM:TypeTemplate(Attribute)==%><%==SIM:Space==%>
                <%==SIM:Attribute.Name==%><%==SIM:Line==%>
                {<%==SIM:StartBlock==%><%==SIM:Line==%>
                    get<%==SIM:Line==%>
                    {<%==SIM:StartBlock==%><%==SIM:Line==%>
                        <%==SIM:Attribute.GetBody==%>
                    <%==SIM:EndBlock==%><%==SIM:Line==%>
                    }<%==SIM:Line==%>
                    <%==SIM:IfNot:Attribute.IsReadOnly==%>
                        set<%==SIM:Line==%>
                        {<%==SIM:StartBlock==%><%==SIM:Line==%>
                            <%==SIM:Attribute.SetBody==%>
                        <%==SIM:EndBlock==%><%==SIM:Line==%>
                        }<%==SIM:Line==%>
                        <%==SIM:EndBlock==%><%==SIM:Line==%>
                    <%==SIM:EndIf==%>
                <%==SIM:EndBlock==%><%==SIM:Line==%>
                }<%==SIM:Line==%>
                <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
            <%==SIM:EndIf==%>
        <%==SIM:EndIf==%>
    <%==SIM:EndFor==%>

    <%==SIM:ForEach:Element.AllAttributes==%>
        <%==SIM:If:Attribute.HasStereotype("event")==%>
            <%==SIM:If:Documentation==%><%==SIM:If:Attribute.HasDocumentation==%>
                /// <summary><%==SIM:Line==%>
            <%==SIM:ForEach:Attribute.SimpleHtmlDocumentationLines==%>
                /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
            <%==SIM:EndFor==%>
                /// </summary><%==SIM:Line==%>
            <%==SIM:EndIf==%><%==SIM:EndIf==%>

            <%==SIM:ForEach:Attribute.TaggedValues("Annotation")==%>
            [<%==SIM:TaggedValue.Value==%>]<%==SIM:Line==%>
            <%==SIM:EndFor==%>

            <%==SIM:Attribute.Visibility==%> event <%==SIM:TypeTemplate(Attribute)==%><%==SIM:Space==%><%==SIM:Attribute.Name==%>;
            <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
        <%==SIM:EndIf==%>
    <%==SIM:EndFor==%>
        
    <%==SIM:If:Element.HasAttributes==%><%==SIM:If:Element.HasOperations==%><%==SIM:Line(2)==%><%==SIM:EndIf==%><%==SIM:EndIf==%>

    <%==SIM:ForEach:Element.Constructors==%>            
        <%==SIM:Line==%>        
        <%==SIM:If:Documentation==%><%==SIM:If:Constructor.HasDocumentation==%>
        /// <summary><%==SIM:Line==%>
        <%==SIM:ForEach:Constructor.SimpleHtmlDocumentationLines==%>
        /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
        <%==SIM:EndFor==%>
        /// </summary><%==SIM:Line==%>
        <%==SIM:ForEach:Constructor.Parameters==%>
        /// <param name="<%==SIM:Parameter.Name==%>"><%==SIM:ToSingleLine(Parameter.Documentation)==%></param><%==SIM:Line==%>
        <%==SIM:EndFor==%>
        <%==SIM:EndIf==%><%==SIM:EndIf==%>

        <%==SIM:Constructor.Visibility==%><%==SIM:If:Constructor.IsStatic==%> static<%==SIM:EndIf==%> <%==SIM:Element.Name==%> (<%==SIM:ForEach:Constructor.Parameters==%><%==SIM:TypeTemplate(Parameter)==%><%==SIM:Space==%><%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:If:Constructor.IsAbstract==%>;<%==SIM:EndIf==%>
        <%==SIM:Line==%>
                               
            {<%==SIM:StartBlock==%><%==SIM:Line==%>
                <%==SIM:Constructor.SourceCodeBody==%>
            
            <%==SIM:EndBlock==%><%==SIM:Line==%>
            }
            <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
    
    <%==SIM:EndFor==%>
    <%==SIM:Line(1)==%>

    <%==SIM:ForEach:Element.Operations==%>
        <%==SIM:If:Operation.HasStereotype("delegate")==%>
            <%==SIM:Line==%>
            <%==SIM:If:Documentation==%><%==SIM:If:Operation.HasDocumentation==%>
            /// <summary><%==SIM:Line==%>
            <%==SIM:ForEach:Operation.SimpleHtmlDocumentationLines==%>
            /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
            <%==SIM:EndFor==%>
            /// </summary><%==SIM:Line==%>
            <%==SIM:ForEach:Operation.Parameters==%>
            /// <param name="<%==SIM:Parameter.Name==%>"><%==SIM:ToSingleLine(Parameter.Documentation)==%></param><%==SIM:Line==%>
            <%==SIM:EndFor==%>
            <%==SIM:EndIf==%><%==SIM:EndIf==%>

            <%==SIM:ForEach:Operation.TaggedValues("Annotation")==%>
            [<%==SIM:TaggedValue.Value==%>]<%==SIM:Line==%>
            <%==SIM:EndFor==%>

            <%==SIM:Operation.Visibility==%> delegate <%==SIM:If:Operation.HasReturnType==%><%==SIM:TypeTemplate(Operation)==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:TypeTemplate(Parameter)==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);
            <%==SIM:Line==%>                
        <%==SIM:EndIf==%>
    <%==SIM:EndFor==%>

    <%==SIM:ForEach:Element.Operations==%>        
        <%==SIM:IfNot:Operation.HasStereotype("delegate")==%>
            <%==SIM:Line==%>
            <%==SIM:If:Documentation==%><%==SIM:If:Operation.HasDocumentation==%>
            /// <summary><%==SIM:Line==%>
            <%==SIM:ForEach:Operation.SimpleHtmlDocumentationLines==%>
            /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
            <%==SIM:EndFor==%>
            /// </summary><%==SIM:Line==%>
            <%==SIM:ForEach:Operation.Parameters==%>
            /// <param name="<%==SIM:Parameter.Name==%>"><%==SIM:ToSingleLine(Parameter.Documentation)==%></param><%==SIM:Line==%>
            <%==SIM:EndFor==%>
            <%==SIM:EndIf==%><%==SIM:EndIf==%>

            <%==SIM:ForEach:Operation.TaggedValues("Annotation")==%>
            [<%==SIM:TaggedValue.Value==%>]<%==SIM:Line==%>
            <%==SIM:EndFor==%>

            <%==SIM:Operation.Visibility==%><%==SIM:If:Operation.HasStereotype("async")==%> async<%==SIM:EndIf==%><%==SIM:If:Operation.IsStatic==%> static<%==SIM:EndIf==%><%==SIM:If:Operation.IsOverride==%> override<%==SIM:EndIf==%><%==SIM:If:Operation.IsVirtual==%> virtual<%==SIM:EndIf==%><%==SIM:If:Operation.IsAbstract==%> abstract<%==SIM:EndIf==%> <%==SIM:If:Operation.HasReturnType==%><%==SIM:TypeTemplate(Operation)==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:TypeTemplate(Parameter)==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:If:Operation.IsAbstract==%>;<%==SIM:EndIf==%>
            <%==SIM:Line==%>

            <%==SIM:IfNot:Operation.IsAbstract==%>
                {<%==SIM:StartBlock==%><%==SIM:Line==%>
                    <%==SIM:Operation.SourceCodeBody==%>
            
                <%==SIM:EndBlock==%><%==SIM:Line==%>
                }
                <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
                
            <%==SIM:EndIf==%>
        <%==SIM:EndIf==%>
    <%==SIM:EndFor==%>

<%==SIM:EndBlock==%><%==SIM:Line==%>
}
<%==SIM:Line(2)==%>