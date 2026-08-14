#include "<%==SIM:Diagram.Owner.Name==%>.h"

namespace <%==SIM:Diagram.Owner.Namespace==%>
{
    <%==SIM:Diagram.Owner.Name==%>::<%==SIM:Diagram.Owner.Name==%>()
    {
        state = new <%==SIM:Diagram.Elements.FilterByType(initial-state).First.OutRelations.First.To.Name==%>(this);
    }

    <%==SIM:Diagram.Owner.Name==%>::~<%==SIM:Diagram.Owner.Name==%>()
    {
        delete state; // Clean up state on destruction.
    }

    <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%>* <%==SIM:Diagram.Owner.Name==%>::GetState() const
    {
        return state;
    }

    void <%==SIM:Diagram.Owner.Name==%>::SetState(<%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%>* newState)
    {
        if (state != newState) {
            if (state) 
            {
                state->ExitState();                
            }
            state = newState;
            if (state) state->EnterState();
        }
        if (state) state->Do();
    }

    <%==SIM:ForEach:Diagram.Owner.Operations==%>
    <%==SIM:Operation.Visibility==%> <%==SIM:Operation.ReturnType==%> <%==SIM:Diagram.Owner.Name==%>::<%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
    {
        <%==SIM:Operation.SourceCodeBody==%>

        state-><%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);
    }
    <%==SIM:EndFor==%>
}
