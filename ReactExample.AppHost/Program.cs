var builder = DistributedApplication.CreateBuilder(args);

var weatherApi = builder.AddProject<Projects.ReactExample_MinimalApi>("weatherapi")
    .WithExternalHttpEndpoints();

builder.AddNpmApp("react", "../ReactExample.React")
    .WithReference(weatherApi)
    .WaitFor(weatherApi)
    .WithEnvironment("BROWSER", "none") // Disable opening browser on npm start
    .WithHttpEndpoint(env: "PORT")
    .WithExternalHttpEndpoints()
    .PublishAsDockerFile();

builder.Build().Run();
