<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

// Entity <%==SIM:Element.Name==%> --------------------------<%==SIM:Line==%>
<%==SIM:ForEach:Element.DocumentationLines==%>
	// <%==SIM:DocumentationLine==%><%==SIM:Line==%>
<%==SIM:EndFor==%>

public class <%==SIM:Element.Name==%><%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

<%==SIM:ResetUniqueNames==%>
<%==SIM:ForEach:Element.PrimaryKeys(Attribute)==%>
	public <%==SIM:Attribute.TypeName==%> <%==SIM:UniqueName(Attribute.Name)==%> { get; set; }<%==SIM:Line==%>
<%==SIM:EndFor==%><%==SIM:Line==%>

<%==SIM:ForEach:Element.NonPrimaryKeys==%>
	<%==SIM:If:Attribute.IsAutoIncrement==%>[DatabaseGenerated(DatabaseGeneratedOption.Identity)]<%==SIM:Line==%><%==SIM:EndIf==%>
	<%==SIM:IfNot:Attribute.IsNullable==%>[Required]<%==SIM:Line==%><%==SIM:EndIf==%>
	<%==SIM:If:And(Contains(Attribute.OriginalType.Id,"string"),Attribute.HasTypeLength,Not(Contains(ToLower(Attribute.TypeLength), "max")))==%>[MaxLength(<%==SIM:Attribute.TypeLength==%>)]<%==SIM:Line==%><%==SIM:EndIf==%> 
	<%==SIM:If:And(Contains(Attribute.OriginalType.Id, "decimal"),Attribute.HasTypeLength)==%>[Precision(<%==SIM:Attribute.TypeLength==%>)]<%==SIM:Line==%><%==SIM:EndIf==%> 
	<%==SIM:If:Attribute.HasDescription==%>[Comment("<%==SIM:Attribute.Description==%>")]<%==SIM:Line==%><%==SIM:EndIf==%>
	public <%==SIM:Attribute.TypeName==%> <%==SIM:UniqueName(Attribute.Name)==%> { get; set; }<%==SIM:Line==%>
<%==SIM:EndFor==%><%==SIM:Line==%>


<%==SIM:ForEach:Element.References==%>
	<%==SIM:Set:RefName===%>	
	<%==SIM:ForEach:Reference.ForeignKeyAttributes(FKA)==%><%==SIM:Set:RefName=Concat(RefName,RemoveEnd(FKA.Name,"ID"))==%><%==SIM:EndFor==%>

	public <%==SIM:Reference.PrimaryKeyEntity.Name==%> <%==SIM:UniqueName(RefName)==%> { get; set; }<%==SIM:Line==%>
<%==SIM:EndFor==%><%==SIM:Line==%>

<%==SIM:ForEach:Element.InverseReferences==%>
	<%==SIM:Set:RefName===%>	
	<%==SIM:ForEach:Reference.ForeignKeyAttributes(FKA)==%><%==SIM:Set:RefName=Concat(RefName,RemoveEnd(FKA.Name,"ID"))==%><%==SIM:EndFor==%>
	<%==SIM:Set:RefName=Concat(RefName, Reference.ForeignKeyEntity.Name)==%>

	public ICollection<<%==SIM:Reference.ForeignKeyEntity.Name==%>> <%==SIM:UniqueName(GetPlural(RefName))==%> { get; set; }<%==SIM:Line==%>
<%==SIM:EndFor==%><%==SIM:Line==%>

<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%>
<%==SIM:EndIf==%>


