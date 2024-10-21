using ManejoInventario_AngularTS_.NET_CORE.Server.Models;
using Microsoft.EntityFrameworkCore;

public class DB : DbContext
{
    public DB(DbContextOptions<DB> options) : base(options)
    {
    }
    public DbSet<Tarea> Tarea { get; set; }
    public DbSet<Prioridad> Prioridad { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlServer("Server=DESKTOP-59VO0OP\\SQLEXPRESS;Database=Task;Integrated Security=True;TrustServerCertificate=True");

}
