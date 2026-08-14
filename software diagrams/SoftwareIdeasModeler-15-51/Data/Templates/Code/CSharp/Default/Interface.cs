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

<%==SIM:Optional:System Usings==%>
    using System;<%==SIM:Line==%>
    using System.Collections.Generic;<%==SIM:Line==%>
    using System.Collections.Concurrent;<%==SIM:Line==%>
<%==SIM:EndOptional==%>
<%==SIM:ForEach:Imports==%>
    using <%==SIM:Import.Name==%>;
    <%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:Line==%>

namespace <%==SIM:Element.Namespace==%><%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

    <%==SIM:If:Documentation==%><%==SIM:If:Element.HasDocumentation==%>
        /// <summary><%==SIM:Line==%>
    <%==SIM:ForEach:Element.SimpleHtmlDocumentationLines==%>
        /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
    <%==SIM:EndFor==%>
        /// </summary><%==SIM:Line==%>
    <%==SIM:EndIf==%><%==SIM:EndIf==%>
    
    <%==SIM:IfNot:IsEmpty(Element.Visibility)==%><%==SIM:Element.Visibility==%> <%==SIM:EndIf==%>interface <%==SIM:Element.Name==%>

    <%==SIM:If:Element.HasTemplateParameters==%><<%==SIM:ForEach:Element.TemplateParameters==%>
            <%==SIM:Parameter.Name==%>
            <%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%>
        <%==SIM:EndFor==%>><%==SIM:EndIf==%>
    <%==SIM:If:Element.HasTemplateParameterWithKind==%>
        <%==SIM:ForEach:Element.TemplateParameters==%>
            <%==SIM:If:Parameter.HasKind==%> where<%==SIM:Parameter.Name==%> : <%==SIM:Parameter.Kind==%> <%==SIM:EndIf==%>
        <%==SIM:EndFor==%>
    <%==SIM:EndIf==%>

    <%==SIM:If:Element.HasInterfaces==%> : <%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%>

    <%==SIM:Line==%>
    {<%==SIM:StartBlock==%><%==SIM:Line==%>

        <%==SIM:ForEach:Element.AllAttributes==%>            
            <%==SIM:If:Documentation==%><%==SIM:If:Attribute.HasDocumentation==%>
                /// <summary><%==SIM:Line==%>
            <%==SIM:ForEach:Attribute.SimpleHtmlDocumentationLines==%>
                /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
            <%==SIM:EndFor==%>
                /// </summary><%==SIM:Line==%>
            <%==SIM:EndIf==%><%==SIM:EndIf==%>
                
            <%==SIM:TypeTemplate(Attribute)==%><%==SIM:Space==%>
            <%==SIM:Attribute.Name==%>{ get; <%==SIM:IfNot:Attribute.IsReadOnly==%>set;<%==SIM:EndIf==%> }
            <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
                
        <%==SIM:EndFor==%>

        <%==SIM:If:Element.HasAttributes==%><%==SIM:If:Element.HasOperations==%><%==SIM:Line(2)==%><%==SIM:EndIf==%><%==SIM:EndIf==%>

        <%==SIM:ForEach:Element.Operations==%>
            <%==SIM:If:Documentation==%><%==SIM:If:Operation.HasDocumentation==%>
                /// <summary><%==SIM:Line==%>
            <%==SIM:ForEach:Operation.SimpleHtmlDocumentationLines==%>
                /// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
            <%==SIM:EndFor==%>
                /// </summary><%==SIM:Line==%>
            <%==SIM:ForEach:Operation.Parameters==%>
                /// <param name="<%==SIM:Parameter.Name==%>"><%==SIM:ToSingleLine(Parameter.Documentation)==%></param><%==SIM:Line==%>
            <%==SIM:EndFor==%><%==SIM:Line==%>
            <%==SIM:EndIf==%><%==SIM:EndIf==%>

            <%==SIM:If:Operation.HasReturnType==%><%==SIM:TypeTemplate(Operation)==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);            

            <%==SIM:Line==%>
        <%==SIM:EndFor==%>

    <%==SIM:EndBlock==%><%==SIM:Line==%>
    }

    <%==SIM:EndBlock==%><%==SIM:Line==%>
}