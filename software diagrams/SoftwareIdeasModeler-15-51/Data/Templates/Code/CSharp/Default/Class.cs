<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>
<%==SIM:Set:private=private==%><%==SIM:Set:protected=protected==%><%==SIM:Set:package=internal==%><%==SIM:Set:public=public==%>

<%==SIM:UserInput:ArrayType=Choice("Array type",Array,IEnumerable,ICollection,IList,List)==%>
<%==SIM:UserInput:Documentation=YesNo("Documentation")==%>
<%==SIM:UserInput:IndentationSize=Number("Indentation size",4)==%>
<%==SIM:UserInput:IndentationChar=Choice("Indentation char",Space,Tab)==%>
<%==SIM:If:Eq(IndentationChar,"Tab")==%><%==SIM:SetTabIndent==%><%==SIM:Else==%><%==SIM:SetSpaceIndent==%><%==SIM:EndIf==%><%==SIM:IndentSize(IndentationSize)==%>
    
<%==SIM:Template:TypeTemplate(Typable)==%>
<%==SIM:If:Or(Typable.IsArray,Typable.ReturnIsArray)==%>
<%==SIM:If:Typable.IsUnique==%><%==SIM:If:Typable.IsOrdered==%>SortedSet<<%==SIM:Typable.Type==%>><%==SIM:Else==%>HashSet<<%==SIM:Typable.Type==%>><%==SIM:EndIf==%>
<%==SIM:Else==%>
<%==SIM:If:Typable.IsOrdered==%><%==SIM:If:Or(Eq(ArrayType,"Array"), IsEmpty(ArrayType))==%><%==SIM:Typable.Type==%>[]<%==SIM:Else==%><%==SIM:ArrayType==%><<%==SIM:Typable.Type==%>><%==SIM:EndIf==%>
<%==SIM:Else==%>ConcurrentBag<<%==SIM:Typable.Type==%>><%==SIM:EndIf==%>
<%==SIM:EndIf==%>
<%==SIM:Else==%>
<%==SIM:Typable.Type==%>
<%==SIM:EndIf==%>
<%==SIM:EndTemplate==%>

<%==SIM:Template:PrimaryConstructor(Element)==%>
    <%==SIM:Set:NextParam=False==%>
    <%==SIM:ForEach:Element.AllAttributes==%><%==SIM:If:Attribute.HasStereotype("primary")==%><%==SIM:If:NextParam==%>, <%==SIM:Else==%>(<%==SIM:EndIf==%><%==SIM:ForEach:Attribute.TaggedValues("Annotation")==%>[<%==SIM:TaggedValue.Value==%>]<%==SIM:Line==%><%==SIM:EndFor==%><%==SIM:TypeTemplate(Attribute)==%> <%==SIM:Attribute.Name==%><%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%><%==SIM:Set:NextParam=True==%><%==SIM:EndIf==%><%==SIM:EndFor==%>
    <%==SIM:If:NextParam==%>)<%==SIM:EndIf==%>
<%==SIM:EndTemplate==%>

<%==SIM:IfNot:Element.IsContained==%>

<%==SIM:Optional:System Usings==%>
    using System;<%==SIM:Line==%>
    using System.Collections.Generic;<%==SIM:Line==%>
    using System.Collections.Concurrent;<%==SIM:Line==%>
<%==SIM:EndOptional==%>
<%==SIM:ForEach:Imports==%>    
    using <%==SIM:Import.Name==%>;<%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:Line==%>

<%==SIM:If:Documentation==%><%==SIM:If:Element.Repository.HasDocumentation==%>
    /// <summary><%==SIM:Line==%>
<%==SIM:ForEach:Element.Repository.SimpleHtmlDocumentationLines==%>
    /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>
    /// </summary><%==SIM:Line==%>
    <%==SIM:If:Element.HasDocumentation("Example")==%>
    /// <example><%==SIM:Line==%>
    <%==SIM:ForEach: Element.SimpleHtmlDocumentationLines(,"Example")==%>
    /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
    <%==SIM:EndFor==%>
    /// </example><%==SIM:Line==%>
    <%==SIM:EndIf==%>
<%==SIM:EndIf==%><%==SIM:EndIf==%>
namespace <%==SIM:Element.Namespace==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

    <%==SIM:If:Documentation==%><%==SIM:If:Element.HasDocumentation==%>
    /// <summary><%==SIM:Line==%>
<%==SIM:ForEach:Element.SimpleHtmlDocumentationLines==%>
    /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>
    /// </summary><%==SIM:Line==%>
    <%==SIM:EndIf==%><%==SIM:EndIf==%>
    
    <%==SIM:ForEach:Element.TaggedValues("Annotation")==%>
    [<%==SIM:TaggedValue.Value==%>]<%==SIM:Line==%>
    <%==SIM:EndFor==%>

    <%==SIM:IfNot:IsEmpty(Element.Visibility)==%><%==SIM:Element.Visibility==%> <%==SIM:EndIf==%><%==SIM:If:Element.IsStatic==%>static <%==SIM:EndIf==%><%==SIM:If:Element.IsLeaf==%>sealed <%==SIM:EndIf==%><%==SIM:If:Element.IsAbstract==%>abstract <%==SIM:EndIf==%><%==SIM:If:Element.HasStereotype("record")==%>record <%==SIM:Else==%>class <%==SIM:EndIf==%><%==SIM:Element.Name==%><%==SIM:PrimaryConstructor(Element)==%>
    
    <%==SIM:If:Element.HasTemplateParameters==%><<%==SIM:ForEach:Element.TemplateParameters==%>
            <%==SIM:Parameter.Name==%>
            <%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%>
        <%==SIM:EndFor==%>><%==SIM:EndIf==%>
    <%==SIM:If:Element.HasTemplateParameterWithKind==%>
        <%==SIM:ForEach:Element.TemplateParameters==%>
            <%==SIM:If:Parameter.HasKind==%> where <%==SIM:Parameter.Name==%> : <%==SIM:Parameter.Kind==%> <%==SIM:EndIf==%>
        <%==SIM:EndFor==%>
    <%==SIM:EndIf==%>

    <%==SIM:If:Or(Element.HasSuperClassOrInterface,Element.HasTemplateBindings)==%> : <%==SIM:Element.SuperClass.Name==%><%==SIM:If:Element.HasInterfaces==%><%==SIM:If:Element.HasSuperClass==%>,<%==SIM:EndIf==%> <%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%><%==SIM:If:Element.HasTemplateBindings==%><%==SIM:If:Or(Element.HasSuperClass,Element.HasInterfaces)==%>,<%==SIM:EndIf==%> <%==SIM:ForEach:Element.TemplateBindings==%><%==SIM:TemplateBinding.Template.Name==%><<%==SIM:ForEach:TemplateBinding.Substitutions==%><%==SIM:Substitution.ActualValue==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%><%==SIM:EndIf==%>
    <%==SIM:Line==%>
    {<%==SIM:StartBlock==%><%==SIM:Line==%>

        <%==SIM:Optional:Regions==%>#region Nested<%==SIM:Line==%><%==SIM:EndOptional==%>
        <%==SIM:ForEach:Element.NestedClasses==%>
            <%==SIM:Include(NestedClass.cs,NestedClass,False)==%>
        <%==SIM:EndFor==%>
        <%==SIM:ForEach:Element.InRelations==%>
            <%==SIM:If:And(Equals(Relation.ElementType,"containment"), Equals(Relation.From.ElementType,"enumeration"))==%>
                <%==SIM:Include(NestedEnum.cs, Relation.From, False)==%>
            <%==SIM:EndIf==%>
        <%==SIM:EndFor==%>
        <%==SIM:Optional:Regions==%><%==SIM:Line==%>#endregion<%==SIM:Line==%><%==SIM:EndOptional==%>

        <%==SIM:Optional:Regions==%>#region Fields<%==SIM:Line==%><%==SIM:EndOptional==%>
        <%==SIM:ForEach:Element.AllAttributes==%>
            <%==SIM:IfNot:Or(Attribute.HasStereotype("property"),Attribute.HasStereotype("prop"), Attribute.HasStereotype("event"),Attribute.HasStereotype("primary"))==%>
                <%==SIM:If:Documentation==%><%==SIM:If:Attribute.HasDocumentation==%>
                <%==SIM:ForEach:Attribute.SimpleHtmlDocumentationLines==%>
                    //<%==SIM:DocumentationLine==%>
                    <%==SIM:Line==%>
                <%==SIM:EndFor==%>
                <%==SIM:EndIf==%><%==SIM:EndIf==%>

                <%==SIM:ForEach:Attribute.TaggedValues("Annotation")==%>
                [<%==SIM:TaggedValue.Value==%>]<%==SIM:Line==%>
                <%==SIM:EndFor==%>

                <%==SIM:Attribute.Visibility==%><%==SIM:If:Attribute.IsStatic==%> static<%==SIM:EndIf==%><%==SIM:If:Attribute.IsReadOnly==%> readonly<%==SIM:EndIf==%> <%==SIM:TypeTemplate(Attribute)==%> <%==SIM:Attribute.Name==%>
                <%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>;
                <%==SIM:Line==%>
            <%==SIM:EndIf==%>
        <%==SIM:EndFor==%>
        <%==SIM:Optional:Regions==%><%==SIM:Line==%>#endregion<%==SIM:Line==%><%==SIM:EndOptional==%>
        <%==SIM:Line==%>

        <%==SIM:Optional:Regions==%>#region Properties<%==SIM:Line==%><%==SIM:EndOptional==%>
        <%==SIM:ForEach:Element.AllAttributes==%>
            <%==SIM:If:Or(Attribute.HasStereotype("property"),Attribute.HasStereotype("prop"))==%>
                <%==SIM:If:Documentation==%>
                <%==SIM:If:Attribute.HasDocumentation==%>
                    /// <summary><%==SIM:Line==%>
                <%==SIM:ForEach:Attribute.SimpleHtmlDocumentationLines==%>
                    /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
                <%==SIM:EndFor==%>
                    /// </summary><%==SIM:Line==%>
                <%==SIM:EndIf==%>
                <%==SIM:EndIf==%>

                <%==SIM:ForEach:Attribute.TaggedValues("Annotation")==%>
                [<%==SIM:TaggedValue.Value==%>]<%==SIM:Line==%>
                <%==SIM:EndFor==%>

                <%==SIM:If:And(IsEmpty(Attribute.GetBody),IsEmpty(Attribute.SetBody))==%>
                    <%==SIM:Attribute.Visibility==%><%==SIM:If:Attribute.IsStatic==%> static<%==SIM:EndIf==%> <%==SIM:TypeTemplate(Attribute)==%> <%==SIM:Attribute.Name==%>
                    { get; <%==SIM:IfNot:Attribute.IsReadOnly==%>set;<%==SIM:EndIf==%> }<%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%>;<%==SIM:EndIf==%>
                    <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
                <%==SIM:Else==%>
                    <%==SIM:Attribute.Visibility==%><%==SIM:If:Attribute.IsStatic==%> static<%==SIM:EndIf==%> <%==SIM:TypeTemplate(Attribute)==%> 
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
        <%==SIM:Optional:Regions==%><%==SIM:Line==%>#endregion<%==SIM:Line==%><%==SIM:EndOptional==%>

        <%==SIM:Optional:Regions==%>#region Events<%==SIM:Line==%><%==SIM:EndOptional==%>
        <%==SIM:ForEach:Element.AllAttributes==%>
            <%==SIM:If:Attribute.HasStereotype("event")==%>
                <%==SIM:If:Documentation==%>
                <%==SIM:If:Attribute.HasDocumentation==%>
                    /// <summary><%==SIM:Line==%>
                <%==SIM:ForEach:Attribute.SimpleHtmlDocumentationLines==%>
                    /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
                <%==SIM:EndFor==%>
                    /// </summary><%==SIM:Line==%>
                <%==SIM:EndIf==%>
                <%==SIM:EndIf==%>

                <%==SIM:ForEach:Attribute.TaggedValues("Annotation")==%>
                [<%==SIM:TaggedValue.Value==%>]<%==SIM:Line==%>
                <%==SIM:EndFor==%>

                <%==SIM:Attribute.Visibility==%> event <%==SIM:TypeTemplate(Attribute)==%> <%==SIM:Attribute.Name==%>;
                <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
            <%==SIM:EndIf==%>
        <%==SIM:EndFor==%>
        <%==SIM:Optional:Regions==%><%==SIM:Line==%>#endregion<%==SIM:Line==%><%==SIM:EndOptional==%>
        
        <%==SIM:If:Element.HasAttributes==%><%==SIM:If:Element.HasOperations==%><%==SIM:Line(2)==%><%==SIM:EndIf==%><%==SIM:EndIf==%>

        <%==SIM:Optional:Regions==%>#region Constructors<%==SIM:Line==%><%==SIM:EndOptional==%>
        <%==SIM:ForEach:Element.Constructors==%>            
            <%==SIM:Line==%>
                <%==SIM:If:Documentation==%><%==SIM:If:Contructor.HasDocumentation==%>
                    /// <summary><%==SIM:Line==%>
                <%==SIM:ForEach:Constructor.SimpleHtmlDocumentationLines==%>
                    /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
                <%==SIM:EndFor==%>
                    /// </summary><%==SIM:Line==%>
                <%==SIM:ForEach:Constructor.Parameters==%>
                    /// <param name="<%==SIM:Parameter.Name==%>"><%==SIM:ToSingleLine(Parameter.Documentation)==%></param><%==SIM:Line==%>
                <%==SIM:EndFor==%>
                <%==SIM:EndIf==%><%==SIM:EndIf==%>

            <%==SIM:Constructor.Visibility==%><%==SIM:If:Constructor.IsStatic==%> static<%==SIM:EndIf==%> <%==SIM:Element.Name==%> (<%==SIM:ForEach:Constructor.Parameters==%><%==SIM:TypeTemplate(Parameter)==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
            <%==SIM:Line==%>
                               
                {<%==SIM:StartBlock==%><%==SIM:Line==%>
                    <%==SIM:Constructor.SourceCodeBody==%>
            
                <%==SIM:EndBlock==%><%==SIM:Line==%>
                }
                <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
    
        <%==SIM:EndFor==%>
        <%==SIM:Optional:Regions==%><%==SIM:Line==%>#endregion<%==SIM:Line==%><%==SIM:EndOptional==%>        
        <%==SIM:Line(1)==%>

        <%==SIM:Optional:Regions==%>#region Delegates<%==SIM:Line==%><%==SIM:EndOptional==%>
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
        <%==SIM:Optional:Regions==%><%==SIM:Line==%>#endregion<%==SIM:Line==%><%==SIM:EndOptional==%>

        <%==SIM:Optional:Regions==%>#region Operations<%==SIM:Line==%><%==SIM:EndOptional==%>
        <%==SIM:ForEach:Element.Operations==%>        
            <%==SIM:IfNot:Operation.HasStereotype("delegate")==%>
                <%==SIM:Line==%>
                <%==SIM:If:Documentation==%><%==SIM:If:Or(Operation.HasDocumentation,Operation.HasNestedDocumentation)==%>
                    /// <summary><%==SIM:Line==%>
                <%==SIM:ForEach:Operation.SimpleHtmlDocumentationLines==%>
                    /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
                <%==SIM:EndFor==%>
                    /// </summary><%==SIM:Line==%>
                <%==SIM:ForEach:Operation.Parameters==%>
                    /// <param name="<%==SIM:Parameter.Name==%>"><%==SIM:ToSingleLine(Parameter.Documentation)==%></param><%==SIM:Line==%>                    
                <%==SIM:EndFor==%>
                    /// <returns><%==SIM:ToSingleLine(Operation.Documentation("Return"))==%></returns><%==SIM:Line==%>
                <%==SIM:If:Operation.HasDocumentation("Example")==%>
                    /// <example><%==SIM:Line==%>
                <%==SIM:ForEach:Operation.SimpleHtmlDocumentationLines(,"Example")==%>
                    /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
                <%==SIM:EndFor==%>
                    /// </example><%==SIM:Line==%>
                <%==SIM:EndIf==%>
                <%==SIM:EndIf==%><%==SIM:EndIf==%>

                <%==SIM:ForEach:Operation.TaggedValues("Annotation")==%>
                [<%==SIM:TaggedValue.Value==%>]<%==SIM:Line==%>
                <%==SIM:EndFor==%>

                <%==SIM:Operation.Visibility==%><%==SIM:If:Operation.HasStereotype("async")==%> async<%==SIM:EndIf==%><%==SIM:If:Operation.IsStatic==%> static<%==SIM:EndIf==%><%==SIM:If:Operation.IsOverride==%> override<%==SIM:EndIf==%><%==SIM:If:Operation.IsVirtual==%> virtual<%==SIM:EndIf==%><%==SIM:If:Operation.IsAbstract==%> abstract<%==SIM:EndIf==%> <%==SIM:If:Operation.HasReturnType==%><%==SIM:TypeTemplate(Operation) ==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:TypeTemplate(Parameter)==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:If:Operation.IsAbstract==%>;<%==SIM:EndIf==%>
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
        <%==SIM:Optional:Regions==%><%==SIM:Line==%>#endregion<%==SIM:Line==%><%==SIM:EndOptional==%>

    <%==SIM:EndBlock==%><%==SIM:Line==%>
    }

<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%>
<%==SIM:EndIf==%>