using KNU.Lingua.Movies.Services.GenrePredictor;
using KNU.Lingua.Movies.Services.MovieLoader;
using KNU.Lingua.Movies.Services.PorterStemmerFilter;
using KNU.Lingua.Movies.Services.ReviewPredictor;
using KNU.Lingua.Movies.Services.StopWordsFilter;
using KNU.Lingua.Movies.Services.TagManager;
using KNU.Lingua.Movies.Services.TagService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KNU.Lingua.Movies
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddScoped<IStopWordsFilter, StopWordsFilter>();
            services.AddScoped<IPorterStemmerFilter, PorterStemmerFilter>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<ITagManager, TagManager>();
            services.AddScoped<IGenrePredictor, GenrePredictor>();
            services.AddScoped<IMovieLoader, MovieLoader>();
            services.AddScoped<IReviewPredictor, ReviewPredictor>();

            services.AddHttpClient();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
