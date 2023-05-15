
# How to load .NET configuration from AWS Secrets Manager

https://aws.amazon.com/blogs/modernizing-with-aws/how-to-load-net-configuration-from-aws-secrets-manager/

1. dotnet new webapi -o TestSecretManagerWebApi

1.1 Install AWS Toolkit for Visual Studio

1.2 Configure IAM Access Key

2. Add Package reference to AWSSDK.SecretsManager

2. Add Package reference to AWSSDK.SecretsManager.Caching

3.In Programs.cs : 

builder.Configuration.AddAmazonSecretsManager("eu-west-3", "development/TestSecretManagerWebApi/Credentials");

then

builder.Services.Configure<MyApiCredentials>(builder.Configuration);

then 
builder.Services.AddScoped<MyService>();

where MyApiCredential are...
and
MyService is ...

3. 

4. 

5. 

9. see also Documents folder

#Add authorisation for current user to use Secret Manager

GetSecretValue operation is not authorized error with AWS Secrets Manager https://stackoverflow.com/questions/66757368/getsecretvalue-operation-is-not-authorized-error-with-aws-secrets-manager

1.Open the IAM Dashboard by searching for IAM on the AWS Search Bar.

2.Click on "Users" or "Roles" on the left side.

3.Search for the user or role and open it.

4.Click "Add Permissions" or "Attach Policies".

5.For users, click "Attach existing policies directly". (Roles don't need this step.)

6.If you search and can't find a suitable policy, click "Create Policy".

7.Choose "Secrets Manager" as service and "GetSecretValue" as Action (You can search for these on each step.)


8.Click "Add ARN" under Resources and enter the region code as well as the secret ID with the 6-char mask. The preview ARN should reflect your complete ARN: arn:aws:secretsmanager:region:12345678910:secret:DatabaseSecret-??????

9.Click "Add" then "Next: Tags" then "Next: Review".

10.Enter a name within the constraints, and click "Create policy".

11.Go back to the Attach Policy page and click the Refresh button (just above the table, on the right side).

12.Search for your policy, click the checkbox and click "Attach policy".

13.Test your application again.