<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:IfNot:Element.IsContained==%>
<%==SIM:Set:private=#==%>
<%==SIM:Set:protected===%>
<%==SIM:Set:package===%>
<%==SIM:Set:public===%>

/**<%==SIM:Line==%>
<%==SIM:ForEach:Element.DocumentationLines==%>
    *<%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>
    * @interface<%==SIM:Line==%>
    * @typedef {<%==SIM:If:Element.HasInterfaces==%><%==SIM:ForEach:Element.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%> & <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%><%==SIM:EndIf==%><%==SIM:Element.Name==%>Ext} <%==SIM:Element.Name==%><%==SIM:Line==%>
    * @typedef <%==SIM:Element.Name==%>Ext<%==SIM:Line==%>
    
    <%==SIM:ForEach:Element.AllAttributes==%>
    * @property {<%==SIM:Attribute.Type==%><%==SIM:If:Attribute.IsArray==%>[]<%==SIM:EndIf==%>} <%==SIM:Attribute.Name==%> <%==SIM:Attribute.Documentation==%><%==SIM:Line==%>
    <%==SIM:EndFor==%>

    <%==SIM:ForEach:Element.Operations==%>
    * @property {(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%>: <%==SIM:Parameter.Type==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)=><%==SIM:If:Operation.HasReturnType==%><%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%>} <%==SIM:Operation.Name==%> <%==SIM:Operation.Documentation==%><%==SIM:Line==%>
    <%==SIM:EndFor==%>
    <%==SIM:Line==%>
*/<%==SIM:Line==%>
<%==SIM:EndIf==%>