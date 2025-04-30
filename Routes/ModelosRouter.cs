using AppModelos.Data;
using AppModelos.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AppModelos.Routes
{
    public static class ModelosRouter
    {
        public static void ModelosRouters(this WebApplication app)
        {
            var router = app.MapGroup("modelos");

            router.MapPost("", async (ModeloRequest req, ModeloContext context) =>
            {
               var modelo = new ModeloModel(req.titulo, req.descricao);
                await context.AddAsync(modelo);
                await context.SaveChangesAsync();  
            });

            router.MapGet("", async (ModeloContext context) =>
            {
                var modelos = await context.Modelos.ToListAsync();
                return Results.Ok(modelos);
            });

            router.MapGet("ativos", async (ModeloContext context) =>
            {
                var modelos = await context.Modelos.Where(x => x.Ativo).ToListAsync();
                return Results.Ok(modelos);
            });

            router.MapPut("{id:guid}", async (Guid id, ModeloRequest req, ModeloContext context) =>
            {
                var modelo = await context.Modelos.FirstOrDefaultAsync(x => x.Id == id);
                if (modelo == null)
                    return Results.NotFound();

                if (!string.IsNullOrEmpty(req.titulo))
                    modelo.MudaTitulo(req.titulo);

                if (!string.IsNullOrEmpty(req.descricao))
                    modelo.MudaDescricao(req.descricao);

                await context.SaveChangesAsync();

                return Results.Ok(modelo);
            });

            router.MapDelete("{id:guid}", async (Guid id, ModeloContext context) =>
            {
                var modelo = await context.Modelos.FirstOrDefaultAsync(x => x.Id == id);
                if (modelo == null)
                    return Results.NotFound();

                modelo.DesativaModelo();
                await context.SaveChangesAsync();

                return Results.Ok(modelo);
            });
        }

    }
}
