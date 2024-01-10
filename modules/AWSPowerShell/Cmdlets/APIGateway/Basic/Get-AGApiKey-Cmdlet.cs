/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.APIGateway;
using Amazon.APIGateway.Model;

namespace Amazon.PowerShell.Cmdlets.AG
{
    /// <summary>
    /// Gets information about the current ApiKey resource.
    /// </summary>
    [Cmdlet("Get", "AGApiKey")]
    [OutputType("Amazon.APIGateway.Model.GetApiKeyResponse")]
    [AWSCmdlet("Calls the Amazon API Gateway GetApiKey API operation.", Operation = new[] {"GetApiKey"}, SelectReturnType = typeof(Amazon.APIGateway.Model.GetApiKeyResponse))]
    [AWSCmdletOutput("Amazon.APIGateway.Model.GetApiKeyResponse",
        "This cmdlet returns an Amazon.APIGateway.Model.GetApiKeyResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetAGApiKeyCmdlet : AmazonAPIGatewayClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ApiKey
        /// <summary>
        /// <para>
        /// <para>The identifier of the ApiKey resource.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String ApiKey { get; set; }
        #endregion
        
        #region Parameter IncludeValue
        /// <summary>
        /// <para>
        /// <para>A boolean flag to specify whether (<c>true</c>) or not (<c>false</c>) the result contains
        /// the key value.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? IncludeValue { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.APIGateway.Model.GetApiKeyResponse).
        /// Specifying the name of a property of type Amazon.APIGateway.Model.GetApiKeyResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.APIGateway.Model.GetApiKeyResponse, GetAGApiKeyCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
            }
            context.ApiKey = this.ApiKey;
            #if MODULAR
            if (this.ApiKey == null && ParameterWasBound(nameof(this.ApiKey)))
            {
                WriteWarning("You are passing $null as a value for parameter ApiKey which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IncludeValue = this.IncludeValue;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.APIGateway.Model.GetApiKeyRequest();
            
            if (cmdletContext.ApiKey != null)
            {
                request.ApiKey = cmdletContext.ApiKey;
            }
            if (cmdletContext.IncludeValue != null)
            {
                request.IncludeValue = cmdletContext.IncludeValue.Value;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.APIGateway.Model.GetApiKeyResponse CallAWSServiceOperation(IAmazonAPIGateway client, Amazon.APIGateway.Model.GetApiKeyRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon API Gateway", "GetApiKey");
            try
            {
                #if DESKTOP
                return client.GetApiKey(request);
                #elif CORECLR
                return client.GetApiKeyAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String ApiKey { get; set; }
            public System.Boolean? IncludeValue { get; set; }
            public System.Func<Amazon.APIGateway.Model.GetApiKeyResponse, GetAGApiKeyCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
