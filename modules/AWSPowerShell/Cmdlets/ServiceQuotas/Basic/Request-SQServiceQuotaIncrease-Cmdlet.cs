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
using Amazon.ServiceQuotas;
using Amazon.ServiceQuotas.Model;

namespace Amazon.PowerShell.Cmdlets.SQ
{
    /// <summary>
    /// Submits a quota increase request for the specified quota.
    /// </summary>
    [Cmdlet("Request", "SQServiceQuotaIncrease", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ServiceQuotas.Model.RequestedServiceQuotaChange")]
    [AWSCmdlet("Calls the AWS Service Quotas RequestServiceQuotaIncrease API operation.", Operation = new[] {"RequestServiceQuotaIncrease"}, SelectReturnType = typeof(Amazon.ServiceQuotas.Model.RequestServiceQuotaIncreaseResponse))]
    [AWSCmdletOutput("Amazon.ServiceQuotas.Model.RequestedServiceQuotaChange or Amazon.ServiceQuotas.Model.RequestServiceQuotaIncreaseResponse",
        "This cmdlet returns an Amazon.ServiceQuotas.Model.RequestedServiceQuotaChange object.",
        "The service call response (type Amazon.ServiceQuotas.Model.RequestServiceQuotaIncreaseResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RequestSQServiceQuotaIncreaseCmdlet : AmazonServiceQuotasClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter ContextId
        /// <summary>
        /// <para>
        /// <para>Specifies the Amazon Web Services account or resource to which the quota applies.
        /// The value in this field depends on the context scope associated with the specified
        /// service quota.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ContextId { get; set; }
        #endregion
        
        #region Parameter DesiredValue
        /// <summary>
        /// <para>
        /// <para>Specifies the new, increased value for the quota.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.Double? DesiredValue { get; set; }
        #endregion
        
        #region Parameter QuotaCode
        /// <summary>
        /// <para>
        /// <para>Specifies the quota identifier. To find the quota code for a specific quota, use the
        /// <a>ListServiceQuotas</a> operation, and look for the <c>QuotaCode</c> response in
        /// the output for the quota you want.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String QuotaCode { get; set; }
        #endregion
        
        #region Parameter ServiceCode
        /// <summary>
        /// <para>
        /// <para>Specifies the service identifier. To find the service code value for an Amazon Web
        /// Services service, use the <a>ListServices</a> operation.</para>
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
        public System.String ServiceCode { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'RequestedQuota'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ServiceQuotas.Model.RequestServiceQuotaIncreaseResponse).
        /// Specifying the name of a property of type Amazon.ServiceQuotas.Model.RequestServiceQuotaIncreaseResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "RequestedQuota";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the QuotaCode parameter.
        /// The -PassThru parameter is deprecated, use -Select '^QuotaCode' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^QuotaCode' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.QuotaCode), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Request-SQServiceQuotaIncrease (RequestServiceQuotaIncrease)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ServiceQuotas.Model.RequestServiceQuotaIncreaseResponse, RequestSQServiceQuotaIncreaseCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.QuotaCode;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.ContextId = this.ContextId;
            context.DesiredValue = this.DesiredValue;
            #if MODULAR
            if (this.DesiredValue == null && ParameterWasBound(nameof(this.DesiredValue)))
            {
                WriteWarning("You are passing $null as a value for parameter DesiredValue which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.QuotaCode = this.QuotaCode;
            #if MODULAR
            if (this.QuotaCode == null && ParameterWasBound(nameof(this.QuotaCode)))
            {
                WriteWarning("You are passing $null as a value for parameter QuotaCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceCode = this.ServiceCode;
            #if MODULAR
            if (this.ServiceCode == null && ParameterWasBound(nameof(this.ServiceCode)))
            {
                WriteWarning("You are passing $null as a value for parameter ServiceCode which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
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
            var request = new Amazon.ServiceQuotas.Model.RequestServiceQuotaIncreaseRequest();
            
            if (cmdletContext.ContextId != null)
            {
                request.ContextId = cmdletContext.ContextId;
            }
            if (cmdletContext.DesiredValue != null)
            {
                request.DesiredValue = cmdletContext.DesiredValue.Value;
            }
            if (cmdletContext.QuotaCode != null)
            {
                request.QuotaCode = cmdletContext.QuotaCode;
            }
            if (cmdletContext.ServiceCode != null)
            {
                request.ServiceCode = cmdletContext.ServiceCode;
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
        
        private Amazon.ServiceQuotas.Model.RequestServiceQuotaIncreaseResponse CallAWSServiceOperation(IAmazonServiceQuotas client, Amazon.ServiceQuotas.Model.RequestServiceQuotaIncreaseRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Service Quotas", "RequestServiceQuotaIncrease");
            try
            {
                #if DESKTOP
                return client.RequestServiceQuotaIncrease(request);
                #elif CORECLR
                return client.RequestServiceQuotaIncreaseAsync(request).GetAwaiter().GetResult();
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
            public System.String ContextId { get; set; }
            public System.Double? DesiredValue { get; set; }
            public System.String QuotaCode { get; set; }
            public System.String ServiceCode { get; set; }
            public System.Func<Amazon.ServiceQuotas.Model.RequestServiceQuotaIncreaseResponse, RequestSQServiceQuotaIncreaseCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.RequestedQuota;
        }
        
    }
}
