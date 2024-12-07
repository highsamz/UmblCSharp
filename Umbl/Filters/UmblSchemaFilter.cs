namespace Umbl.Filters
{
    using global::Umbl.Models;
    using Microsoft.OpenApi.Any;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;

    namespace Umbl.Filters
    {
        public class UmblSchemaFilter : ISchemaFilter
        {
            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                // Adicionando exemplo para PontoColetaModel
                if (context.Type == typeof(PontoColetaModel))
                {
                    schema.Example = new OpenApiObject
                    {
                        ["capacidade"] = new OpenApiInteger(100),
                        ["email"] = new OpenApiString("ponto@coleta.com"),
                        ["telefone"] = new OpenApiString("(11) 99999-9999"),
                        ["enderecoPontoColetaModel"] = new OpenApiObject
                        {
                            ["logradouro"] = new OpenApiString("Rua Exemplo"),
                            ["cep"] = new OpenApiString("12345-678"),
                            ["numero"] = new OpenApiString("100"),
                            ["cidade"] = new OpenApiString("São Paulo"),
                            ["bairro"] = new OpenApiString("Centro"),
                            ["estado"] = new OpenApiString("SP")
                        },
                        ["materialAceitoModel"] = new OpenApiString("PAPELAO,ISOPOR,PLASTICO,METAL")
                    };
                }

                if (context.Type == typeof(UserModel))
                {
                    schema.Example = new OpenApiObject
                    {
                        ["username"] = new OpenApiString("admin01"),
                        ["password"] = new OpenApiString("pass123"),

                    };
                }
            }
        }
    }
}
