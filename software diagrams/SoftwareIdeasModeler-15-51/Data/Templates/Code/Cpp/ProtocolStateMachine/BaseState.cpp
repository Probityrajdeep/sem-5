<%==SIM:Set:private=private==%>
<%==SIM:Set:protected=protected==%>
<%==SIM:Set:package=protected==%>
<%==SIM:Set:public=public==%>

#include <stdexcept>
#include <memory>

<%==SIM:ForEach:Imports==%>
#include "<%==SIM:Import.Name==%>.h"
<%==SIM:EndFor==%>

namespace <%==SIM:Diagram.Namespace==%> {

    class <%==SIM:Diagram.Owner.Name==%>;

    class <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%> {
        protected:
            <%==SIM:Diagram.Owner.Name==%>* owner;

        public:
            explicit <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%>(<%==SIM:Diagram.Owner.Name==%>* owner) : owner(owner) {}
            virtual ~<%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%>() = default;

            // Prevent copying and assignment
            <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%>(const <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%>&) = delete;
            <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%>& operator=(const <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%>&) = delete;

        <%==SIM:ForEach:Diagram.Owner.Operations==%>
            virtual void <%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>) = 0;
        <%==SIM:EndFor==%>

            virtual void EnterState() = 0;
            virtual void ExitState() = 0;
            virtual void Do() = 0;
    };

}