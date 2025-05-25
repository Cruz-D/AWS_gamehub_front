using AWS_gamehub_front.Services.HttpServices;

namespace AWS_gamehub_front
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient();

            builder.Services.AddScoped<VideogameService>(provider =>
            {
                var httpClient = provider.GetRequiredService<HttpClient>();
                var baseUrl = "http://gamehu-recip-duqgxohmiw6e-1943613613.eu-north-1.elb.amazonaws.com/api/Videogames";
                return new VideogameService(httpClient, baseUrl);
            });

            builder.Services.AddScoped<AuthService>(provider =>
            {
                var httpClient = provider.GetRequiredService<HttpClient>();
                var baseUrl = "http://gamehu-recip-duqgxohmiw6e-1943613613.eu-north-1.elb.amazonaws.com/api/Auth";
                return new AuthService(httpClient, baseUrl);
            });

            builder.Services.AddScoped<CommentsService>(provider =>
            {
                var httpClient = provider.GetRequiredService<HttpClient>();
                var baseUrl = "http://gamehu-recip-duqgxohmiw6e-1943613613.eu-north-1.elb.amazonaws.com/api/Comments";
                return new CommentsService(httpClient, baseUrl);
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Videogame}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
