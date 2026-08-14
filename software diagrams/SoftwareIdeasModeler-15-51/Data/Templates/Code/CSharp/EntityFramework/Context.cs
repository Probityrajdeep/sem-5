<%==SIM:ExplicitWhitespacesOn==%>
<%==SIM:AutoIndentOn==%>

<%==SIM:ForEach:Diagram.DocumentationLines==%>//<%==SIM:DocumentationLine==%>
<%==SIM:EndFor==%>

namespace <%==SIM:Diagram.Namespace==%>
<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>
    
public class <%==SIM:Diagram.Name==%>Context : DbContext<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

    public <%==SIM:Diagram.Name==%>Context(DbContextOptions<<%==SIM:Diagram.Name==%>Context> options) : base(options)<%==SIM:Line==%>
    {<%==SIM:Line==%>
    }<%==SIM:Line(2)==%>

<%==SIM:ForEach:Diagram.Elements(Element)==%><%==SIM:If:Element.OfTypes("class","erd-entity","idef1x-entity")==%>
public DbSet<<%==SIM:Element.Name==%>> <%==SIM:GetPlural(Element.Name)==%> { get; set; }<%==SIM:Line==%>
<%==SIM:EndIf==%>
<%==SIM:EndFor==%>

<%==SIM:Line==%>
protected override void OnModelCreating(ModelBuilder modelBuilder)<%==SIM:Line==%>
{<%==SIM:StartBlock==%><%==SIM:Line==%>

<%==SIM:ForEach:Diagram.Elements(Element)==%><%==SIM:If:Element.OfTypes("class","erd-entity","idef1x-entity")==%>    
    <%==SIM:ResetUniqueNames==%>
    <%==SIM:ForEach:Element.PrimaryKeys(Attribute)==%>
	    <%==SIM:Set:Temp=UniqueName(Attribute.Name)==%>
    <%==SIM:EndFor==%>
    <%==SIM:ForEach:Element.NonPrimaryKeys==%>
	    <%==SIM:Set:Temp=UniqueName(Attribute.Name)==%>
    <%==SIM:EndFor==%>

    modelBuilder.Entity<<%==SIM:Element.Name==%>>().ToTable("<%==SIM:Element.Name==%>"<%==SIM:IfNot:IsEmpty(Element.Schema)==%>,"<%==SIM:Element.Schema==%>"<%==SIM:EndIf==%>)
    <%==SIM:If:Element.HasPrimaryKey==%>
        <%==SIM:StartBlock==%><%==SIM:Line==%>        
        .HasKey(k => new {<%==SIM:ForEach:Element.PrimaryKeys==%>k.<%==SIM:Key.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%>})<%==SIM:Line==%>
        .HasName("<%==SIM:Element.PrimaryKeyName==%>")
    <%==SIM:EndIf==%>

    <%==SIM:CLS==%>;<%==SIM:EndBlock==%><%==SIM:Line(2)==%>
            
    
    <%==SIM:ForEach:Element.InverseReferences==%>
    
    modelBuilder.Entity<<%==SIM:Element.Name==%>>().ToTable("<%==SIM:Element.Name==%>"<%==SIM:IfNot:IsEmpty(Element.Schema)==%>,"<%==SIM:Element.Schema==%>"<%==SIM:EndIf==%>)
	<%==SIM:Set:RefName===%>      
	<%==SIM:ForEach:Reference.ForeignKeyAttributes(FKA)==%><%==SIM:Set:RefName=Concat(RefName,RemoveEnd(FKA.Name,"ID"))==%><%==SIM:EndFor==%>        
    <%==SIM:Set:RefName2=RefName==%>
    <%==SIM:Set:RefName=Concat(RefName, Reference.ForeignKeyEntity.Name)==%>    
    <%==SIM:Set:RefName=UniqueName(GetPlural(RefName))==%>

    <%==SIM:StartBlock==%>
	<%==SIM:CLS==%><%==SIM:Line==%>.HasMany(x => x.<%==SIM:RefName==%>).WithOne(x => x.<%==SIM:RefName2==%>).HasForeignKey(x => new { <%==SIM:ForEach:Reference.ForeignKeyAttributes(FKA)==%>x.<%==SIM:FKA.Name==%><%==SIM:IfNot:IsLastItem==%>, <%==SIM:EndIf==%><%==SIM:EndFor==%> });
    <%==SIM:EndBlock==%><%==SIM:Line==%>
    <%==SIM:EndFor==%><%==SIM:Line==%>


<%==SIM:EndIf==%><%==SIM:EndFor==%>
<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%>

<%==SIM:EndBlock==%><%==SIM:Line==%>
}


<%==SIM:EndBlock==%><%==SIM:Line==%>
}<%==SIM:Line==%> 