<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package=internal==%>
<%==SIM:Set:public=public==%>

<%==SIM:ForEach:Imports==%>
    using <%==SIM:Import.Name==%>;
    <%==SIM:Line==%>
<%==SIM:EndFor==%>
<%==SIM:Line==%>

namespace <%==SIM:Diagram.Owner.Namespace==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

<%==SIM:ForEach:Diagram.Owner.DocumentationLines==%>
    //<%==SIM:DocumentationLine==%>
    <%==SIM:Line==%>
<%==SIM:EndFor==%>
    
    <%==SIM:Diagram.Owner.Visibility==%><%==SIM:If:Diagram.Owner.IsStatic==%> static<%==SIM:EndIf==%><%==SIM:If:Diagram.Owner.IsLeaf==%> sealed<%==SIM:EndIf==%><%==SIM:If:Diagram.Owner.IsAbstract==%> abstract<%==SIM:EndIf==%> class <%==SIM:Diagram.Owner.Name==%>
    
    <%==SIM:If:Diagram.Owner.HasTemplateParameters==%><<%==SIM:ForEach:Diagram.Owner.TemplateParameters==%>
            <%==SIM:Parameter.Name==%>
            <%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%>
        <%==SIM:EndFor==%>><%==SIM:EndIf==%>
    <%==SIM:If:Diagram.Owner.HasTemplateParameterWithKind==%>
        <%==SIM:ForEach:Diagram.Owner.TemplateParameters==%>
            <%==SIM:If:Parameter.HasKind==%> where<%==SIM:Parameter.Name==%> : <%==SIM:Parameter.Kind==%> <%==SIM:EndIf==%>
        <%==SIM:EndFor==%>
    <%==SIM:EndIf==%>

    <%==SIM:If:Diagram.Owner.HasSuperClassOrInterface==%> : <%==SIM:Diagram.Owner.SuperClass.Name==%><%==SIM:If:Diagram.Owner.HasInterfaces==%><%==SIM:If:Diagram.Owner.HasSuperClass==%>,<%==SIM:EndIf==%> <%==SIM:ForEach:Diagram.Owner.Interfaces==%><%==SIM:Interface.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%><%==SIM:EndIf==%><%==SIM:EndIf==%>
    <%==SIM:Line==%>
    {<%==SIM:StartBlock==%><%==SIM:Line==%>

        private <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%><%==SIM:Space==%>state;<%==SIM:Line==%>
        public <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%> State<%==SIM:Line==%>
        {<%==SIM:StartBlock==%><%==SIM:Line==%>
            get { return state; }<%==SIM:Line==%>
            set<%==SIM:Line==%>
            {<%==SIM:StartBlock==%><%==SIM:Line==%>
                if (state != value)<%==SIM:Line==%>
                {<%==SIM:StartBlock==%><%==SIM:Line==%>
                    if (state != null && state != value) state.ExitState();<%==SIM:Line==%>
                    state = value;<%==SIM:Line==%>
                    if (state != null && state != value) state.EnterState();
                    state.Do();
                    <%==SIM:EndBlock==%><%==SIM:Line==%>
                }<%==SIM:EndBlock==%><%==SIM:Line==%>
            }<%==SIM:EndBlock==%><%==SIM:Line==%>        
        }<%==SIM:Line==%>

        <%==SIM:ForEach:Diagram.Owner.NestedClasses==%>
            <%==SIM:Include(NestedClass.cs, NestedClass, False)==%>
        <%==SIM:EndFor==%>

        <%==SIM:ForEach:Diagram.Owner.AllAttributes==%>
            <%==SIM:IfNot:Attribute.HasStereotype("property")==%>
                <%==SIM:ForEach:Attribute.DocumentationLines==%>
                    //<%==SIM:DocumentationLine==%>
                    <%==SIM:Line==%>
                <%==SIM:EndFor==%>

                <%==SIM:Attribute.Visibility==%><%==SIM:If:Attribute.IsStatic==%> static<%==SIM:EndIf==%> <%==SIM:Attribute.Type==%> <%==SIM:If:Attribute.IsArray==%>[]<%==SIM:EndIf==%> 
                <%==SIM:Attribute.Name==%>
                <%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%><%==SIM:EndIf==%>;
                <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
            <%==SIM:EndIf==%>
        <%==SIM:EndFor==%>

        <%==SIM:ForEach:Diagram.Owner.AllAttributes==%>
            <%==SIM:If:Attribute.HasStereotype("property")==%>
                <%==SIM:ForEach:Attribute.DocumentationLines==%>
                    //<%==SIM:DocumentationLine==%>
                    <%==SIM:Line==%>
                <%==SIM:EndFor==%>

                <%==SIM:If:And(IsEmpty(Attribute.GetBody),IsEmpty(Attribute.SetBody))==%>
                    <%==SIM:Attribute.Visibility==%><%==SIM:If:Attribute.IsStatic==%> static<%==SIM:EndIf==%> <%==SIM:Attribute.Type==%> <%==SIM:If:Attribute.IsArray==%>[]<%==SIM:EndIf==%> 
                    <%==SIM:Attribute.Name==%>{ get; set; }<%==SIM:If:Attribute.HasDefaultValue==%> = <%==SIM:Attribute.DefaultValue==%>;<%==SIM:EndIf==%>
                    <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
                <%==SIM:Else==%>
                    <%==SIM:Attribute.Visibility==%><%==SIM:If:Attribute.IsStatic==%> static<%==SIM:EndIf==%> <%==SIM:Attribute.Type==%> <%==SIM:If:Attribute.IsArray==%>[]<%==SIM:EndIf==%> 
                    <%==SIM:Attribute.Name==%><%==SIM:Line==%>
                    {<%==SIM:StartBlock==%><%==SIM:Line==%>
                        get<%==SIM:Line==%>
                        {<%==SIM:StartBlock==%><%==SIM:Line==%>
                            <%==SIM:Attribute.GetBody==%>
                        <%==SIM:EndBlock==%><%==SIM:Line==%>
                        }<%==SIM:Line==%>
                        set<%==SIM:Line==%>
                        {<%==SIM:StartBlock==%><%==SIM:Line==%>
                            <%==SIM:Attribute.SetBody==%>
                        <%==SIM:EndBlock==%><%==SIM:Line==%>
                        }<%==SIM:Line==%>
                    <%==SIM:EndBlock==%><%==SIM:Line==%>
                    }<%==SIM:Line==%>
                    <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
                <%==SIM:EndIf==%>
            <%==SIM:EndIf==%>
        <%==SIM:EndFor==%>
        
        <%==SIM:If:Diagram.Owner.HasAttributes==%><%==SIM:If:Diagram.Owner.HasOperations==%><%==SIM:Line(2)==%><%==SIM:EndIf==%><%==SIM:EndIf==%>

        public <%==SIM:Diagram.Owner.Name==%>()<%==SIM:Line==%>
        {<%==SIM:StartBlock==%><%==SIM:Line==%>
            this.state = new <%==SIM:Diagram.Elements.FilterByType(initial-state).First.OutRelations.First.To.Name==%>(this);
        <%==SIM:EndBlock==%><%==SIM:Line==%>
        }<%==SIM:Line==%>

        <%==SIM:ForEach:Diagram.Owner.Operations==%>
            <%==SIM:Line==%>
            <%==SIM:ForEach:Operation.DocumentationLines==%>        
                //<%==SIM:DocumentationLine==%>
                <%==SIM:Line==%>
            <%==SIM:EndFor==%>

            <%==SIM:Operation.Visibility==%><%==SIM:If:Operation.IsStatic==%> static<%==SIM:EndIf==%><%==SIM:If:Operation.IsOverride==%> override<%==SIM:EndIf==%><%==SIM:If:Operation.IsVirtual==%> virtual<%==SIM:EndIf==%><%==SIM:If:Operation.IsAbstract==%> abstract<%==SIM:EndIf==%> <%==SIM:If:Operation.HasReturnType==%><%==SIM:Operation.ReturnType==%><%==SIM:EndIf==%><%==SIM:IfNot:Operation.HasReturnType==%>void<%==SIM:EndIf==%> <%==SIM:Operation.Name==%> (<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)<%==SIM:If:Operation.IsAbstract==%>;<%==SIM:EndIf==%>
            <%==SIM:Line==%>

            <%==SIM:IfNot:Operation.IsAbstract==%>                        
                {<%==SIM:StartBlock==%><%==SIM:Line==%>
                    <%==SIM:Operation.SourceCodeBody==%>

                    state.<%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);
            
                <%==SIM:EndBlock==%><%==SIM:Line==%>
                }
                <%==SIM:IfNot:IsLastItem==%><%==SIM:Line==%><%==SIM:EndIf==%>
                
            <%==SIM:EndIf==%>
        <%==SIM:EndFor==%>
            

    <%==SIM:EndBlock==%><%==SIM:Line==%>
    }

<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%>
