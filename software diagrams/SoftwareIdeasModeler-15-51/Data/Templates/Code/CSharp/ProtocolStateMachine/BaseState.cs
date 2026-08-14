<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package=internal==%>
<%==SIM:Set:public=public==%>
<%==SIM:ForEach:Imports==%>
using <%==SIM:Import.Name==%>;
<%==SIM:EndFor==%>

namespace <%==SIM:Diagram.Namespace==%>
{
    public abstract class <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%>
    {
        private <%==SIM:Diagram.Owner.Name==%> owner;
        protected <%==SIM:Diagram.Owner.Name==%> Owner
        {
            get { return owner; }
        }

        public <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%>(<%==SIM:Diagram.Owner.Name==%> owner)
        {
            this.owner = owner;
        }

<%==SIM:ForEach:Diagram.Owner.Operations==%>
        public virtual void <%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
        {
            throw new NotSupportedException();
        }
<%==SIM:EndIf==%><%==SIM:EndFor==%>

        public abstract void EnterState();
        
        public abstract void ExitState();

        public abstract void Do();
        
    }

}