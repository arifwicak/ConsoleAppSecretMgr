using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;
using Amazon.SecretsManager.Model.Internal;
using Amazon;


namespace ConsoleAppSecretMgr
{   

    public class SecretManager 
    {
        public string Get(string secretName)
        {
            //var credentials = new StoredProfileAWSCredentials(profileName);
            var config = new AmazonSecretsManagerConfig { RegionEndpoint = RegionEndpoint.USEast2 };
            var client = new AmazonSecretsManagerClient(config);
            //string region = "us-east-2";
            //IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region));

            var request = new GetSecretValueRequest
            {
                SecretId = secretName,
                VersionStage = "AWSCURRENT"
            };

            GetSecretValueResponse response = null;
            
            try
            {
                //response = Task.Run(async () => await client.GetSecretValueAsync(request)).Result;
                response = client.GetSecretValueAsync(request).Result;
            } 
            
            catch (ResourceNotFoundException)
            {
                Console.WriteLine("The requested secret " + secretName + " was not found");
            }
            catch (InvalidRequestException e)
            {
                Console.WriteLine("The request was invalid due to: " + e.Message);
            }
            catch (InvalidParameterException e)
            {
                Console.WriteLine("The request had invalid params: " + e.Message);
            }

            return response?.SecretString;
        }
    }

}