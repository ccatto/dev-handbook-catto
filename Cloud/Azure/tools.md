# to install Azure cli

brew update && brew install azure-cli

> azure-functions-core-tools

```bash
brew tap azure/functions
brew install azure-functions-core-tools@4
# then check
func --version

```

For example, with func you can:

Create a new function app project

func init MyFunctionApp --python


Create a new function inside the app

func new


Run your functions locally

func start


Publish to Azure

func azure functionapp publish <APP_NAME>
