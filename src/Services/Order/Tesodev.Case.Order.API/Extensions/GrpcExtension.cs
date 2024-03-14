using Grpc.Net.ClientFactory;
using Tesodev.Case.BuildingBlocks.Protos;

namespace Tesodev.Case.Order.API.Extensions;

public static class GrpcExtension
{
    public static IServiceCollection AddCustomGrpc(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddGrpcClient<CustomerGrpc.CustomerGrpcClient>(options => SetOptions(options, configuration));

        serviceCollection.AddGrpc();

        return serviceCollection;
    }

    private static void SetOptions(GrpcClientFactoryOptions options, IConfiguration configuration)
    {
        var grpcConfiguration = configuration.GetSection("CustomerGrpcConnectionString").Value;
        options.ChannelOptionsActions.Add(opt => opt.UnsafeUseInsecureChannelCallCredentials = true);
        options.Address = new Uri(grpcConfiguration);
    }
}