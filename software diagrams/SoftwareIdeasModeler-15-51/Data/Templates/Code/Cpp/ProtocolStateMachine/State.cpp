#include "<%==SIM:Element.Name==%>.h"
#include "<%==SIM:Element.Diagram.GetTaggedValue(BaseState,BaseState)==%>.h"
<%==SIM:ForEach:Imports==%>
#include "<%==SIM:Import.Name==%>.h"
<%==SIM:EndFor==%>

namespace <%==SIM:Element.Namespace==%>
{
    <%==SIM:Element.Name==%>::<%==SIM:Element.Name==%>(<%==SIM:Element.Repository.Owner.Name==%>* owner)
        : <%==SIM:Element.Diagram.GetTaggedValue(BaseState,BaseState)==%>(owner)
    {
    }

    void <%==SIM:Element.Name==%>::EnterState()
    {
        <%==SIM:Element.SourceCode(":Entry")==%>
    }

    void <%==SIM:Element.Name==%>::ExitState()
    {
        <%==SIM:Element.SourceCode(":Exit")==%>
    }

    void <%==SIM:Element.Name==%>::Do()
    {
        <%==SIM:Element.SourceCode(":Do")==%>
    }

    <%==SIM:ForEach:Element.Repository.Owner.Operations==%>
    void <%==SIM:Element.Name==%>::<%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>)
    {
        <%==SIM:Element.SourceCode(Operation.Uid)==%>
    
        ChangeState("<%==SIM:Operation.Name==%>");
    }
    <%==SIM:EndFor==%>

    void <%==SIM:Element.Name==%>::ChangeState(const std::string& operation)
    {
        <%==SIM:ForEach:Element.OutRelations.FilterByType(transition)==%>
        <%==SIM:IfNot:IsFirstItem==%>else <%==SIM:EndIf==%>if (<%==SIM:If:IsEmpty(Relation.OperationName)==%>true<%==SIM:Else==%>operation == "<%==SIM:Relation.OperationName==%>" <%==SIM:EndIf==%><%==SIM:IfNot:IsEmpty(Relation.PreCondition)==%> && <%==SIM:Relation.PreCondition==%><%==SIM:EndIf==%>)
        {                
            this->owner->SetState(new <%==SIM:Relation.ToElement.Name==%>(this->owner));
        }
        <%==SIM:EndFor==%>
    }
}
