<%==SIM:AutoIndentOn==%>
<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package=internal==%>
<%==SIM:Set:public=public==%>
<%==SIM:ForEach:Imports==%>
using <%==SIM:Import.Name==%>;
<%==SIM:EndFor==%>

namespace <%==SIM:Element.Namespace==%>
{
    <%==SIM:ForEach:Element.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
    <%==SIM:EndFor==%>public class <%==SIM:Element.Name==%> : <%==SIM:Element.Diagram.GetTaggedValue(BaseState,BaseState)==%>
    {
        public <%==SIM:Element.Name==%>(<%==SIM:Element.Repository.Owner.Name==%> owner)
            : base(owner)
        {
                
        }

<%==SIM:ForEach:Element.Repository.Owner.Operations==%>
        public override void <%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
        {
            <%==SIM:Element.SourceCode(Operation.Uid)==%>
            
            ChangeState("<%==SIM:Operation.Name==%>");
        }
<%==SIM:EndFor==%>

        private void ChangeState(string operation)
        {
            <%==SIM:ForEach:Element.OutRelations.FilterByType(transition)==%>
            <%==SIM:IfNot:IsFirstItem==%>else <%==SIM:EndIf==%>if (operation == "<%==SIM:Relation.OperationName==%>" <%==SIM:IfNot:IsEmpty(Relation.PreCondition)==%> && <%==SIM:Relation.PreCondition==%><%==SIM:EndIf==%>)
            {                
                Owner.State = new <%==SIM:Relation.ToElement.Name==%>(Owner);
            }
            <%==SIM:EndFor==%>
        }

        // <%==SIM:Element.Entry==%>
        public override void EnterState()
        {<%==SIM:StartBlock==%><%==SIM:Line==%>
               <%==SIM:Element.SourceCode(":Entry")==%><%==SIM:EndBlock==%>
        }

        // <%==SIM:Element.Exit==%>
        public override void ExitState()
        {<%==SIM:StartBlock ==%><%==SIM:Line==%>
            <%==SIM:Element.SourceCode(":Exit")==%><%==SIM:EndBlock==%>
        }

        // <%==SIM:Element.Do==%>
        public override void Do()
        {<%==SIM:StartBlock ==%><%==SIM:Line==%>
            <%==SIM:Element.SourceCode(":Do")==%><%==SIM:EndBlock==%>
        }
    }
}