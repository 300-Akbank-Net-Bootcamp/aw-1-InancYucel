using FluentValidation.AspNetCore;
using FluentValidation.Validators;

namespace FluentValidation;

public class Startup
{
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        
        //FluentValidators Install
        services.AddValidatorsFromAssemblyContaining<StuffValidator>(); // register validators
        services.AddFluentValidationAutoValidation(); // the same old MVC pipeline behavior
        services.AddFluentValidationClientsideAdapters(); // for client side
        
        services.AddEndpointsApiExplorer(); // Discovers endpoints
        services.AddSwaggerGen(); //Prepares documentation for Swagger
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        if (env.IsDevelopment()) //If we are working in a development environment, UI is enabled.
        {
            app.UseDeveloperExceptionPage(); //Herhangi bir hata olursa göstersin bize
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(x => { x.MapControllers(); }); //?
    }
}