#pragma once

#include <memory>
#include <string>
#include "<%==SIM:Element.Diagram.GetTaggedValue(BaseState,BaseState)==%>.h"
<%==SIM:ForEach:Imports==%>
#include "<%==SIM:Import.Name==%>.h"
<%==SIM:EndFor==%>

namespace <%==SIM:Element.Namespace==%>
{
    <%==SIM:ForEach:Element.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
    <%==SIM:EndFor==%>
    class <%==SIM:Element.Name==%> : public <%==SIM:Element.Diagram.GetTaggedValue(BaseState,BaseState)==%>
    {
        public:
            explicit <%==SIM:Element.Name==%>(<%==SIM:Element.Repository.Owner.Name==%>* owner);

            void EnterState() override;
            void ExitState() override;
            void Do() override;

            <%==SIM:ForEach:Element.Repository.Owner.Operations==%>
            void <%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>) override;
            <%==SIM:EndFor==%>

        private:
            void ChangeState(const std::string& operation);
    };
}
