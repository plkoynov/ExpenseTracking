namespace ExpenseTracking.WebApi.Endpoints
{
    public static class HomeEndpoints
    {
        public static void MapHomeEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/", () => "Welcome to the Expense Tracking API!")
               .WithName("GetHome")
               .WithTags(nameof(HomeEndpoints));
        }
    }
}