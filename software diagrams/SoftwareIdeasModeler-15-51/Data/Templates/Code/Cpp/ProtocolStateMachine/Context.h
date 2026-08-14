#pragma once

#include <memory> 
#include <string>
#include "<%==SIM:Diagram.Owner.Name==%>.h"
<%==SIM:ForEach:Imports==%>
#include "<%==SIM:Import.Name==%>.h"
<%==SIM:EndFor==%>

namespace <%==SIM:Diagram.Owner.Namespace==%>
{
    <%==SIM:ForEach:Diagram.Owner.DocumentationLines==%>
    //<%==SIM:DocumentationLine==%>
    <%==SIM:EndFor==%>
    <%==SIM:Diagram.Owner.Visibility==%> class <%==SIM:Diagram.Owner.Name==%>
    {
        private:
            <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%>* state;

        public:
            <%==SIM:Diagram.Owner.Name==%>();
            ~<%==SIM:Diagram.Owner.Name==%>();

            <%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%>* GetState() const;
            void SetState(<%==SIM:Diagram.GetTaggedValue(BaseState,BaseState)==%>* newState);

            <%==SIM:ForEach:Diagram.Owner.Operations==%>
            <%==SIM:Operation.Visibility==%> <%==SIM:Operation.ReturnType==%> <%==SIM:Operation.Name==%>(<%==SIM:ForEach:Operation.Parameters==%><%==SIM:Parameter.Type==%> <%==SIM:Parameter.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>);
            <%==SIM:EndFor==%>
    };
}