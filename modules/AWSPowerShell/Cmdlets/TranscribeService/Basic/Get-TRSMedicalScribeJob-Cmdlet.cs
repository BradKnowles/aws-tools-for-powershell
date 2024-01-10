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
using Amazon.TranscribeService;
using Amazon.TranscribeService.Model;

namespace Amazon.PowerShell.Cmdlets.TRS
{
    /// <summary>
    /// Provides information about the specified Medical Scribe job.
    /// 
    ///  
    /// <para>
    /// To view the status of the specified medical transcription job, check the <c>MedicalScribeJobStatus</c>
    /// field. If the status is <c>COMPLETED</c>, the job is finished. You can find the results
    /// at the location specified in <c>MedicalScribeOutput</c>. If the status is <c>FAILED</c>,
    /// <c>FailureReason</c> provides details on why your Medical Scribe job failed.
    /// </para><para>
    /// To get a list of your Medical Scribe jobs, use the operation.
    /// </para>
    /// </summary>
    [Cmdlet("Get", "TRSMedicalScribeJob")]
    [OutputType("Amazon.TranscribeService.Model.MedicalScribeJob")]
    [AWSCmdlet("Calls the Amazon Transcribe Service GetMedicalScribeJob API operation.", Operation = new[] {"GetMedicalScribeJob"}, SelectReturnType = typeof(Amazon.TranscribeService.Model.GetMedicalScribeJobResponse))]
    [AWSCmdletOutput("Amazon.TranscribeService.Model.MedicalScribeJob or Amazon.TranscribeService.Model.GetMedicalScribeJobResponse",
        "This cmdlet returns an Amazon.TranscribeService.Model.MedicalScribeJob object.",
        "The service call response (type Amazon.TranscribeService.Model.GetMedicalScribeJobResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class GetTRSMedicalScribeJobCmdlet : AmazonTranscribeServiceClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter MedicalScribeJobName
        /// <summary>
        /// <para>
        /// <para>The name of the Medical Scribe job you want information about. Job names are case
        /// sensitive.</para>
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
        public System.String MedicalScribeJobName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'MedicalScribeJob'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.TranscribeService.Model.GetMedicalScribeJobResponse).
        /// Specifying the name of a property of type Amazon.TranscribeService.Model.GetMedicalScribeJobResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "MedicalScribeJob";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the MedicalScribeJobName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^MedicalScribeJobName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^MedicalScribeJobName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            this._AWSSignerType = "v4";
            base.ProcessRecord();
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.TranscribeService.Model.GetMedicalScribeJobResponse, GetTRSMedicalScribeJobCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.MedicalScribeJobName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.MedicalScribeJobName = this.MedicalScribeJobName;
            #if MODULAR
            if (this.MedicalScribeJobName == null && ParameterWasBound(nameof(this.MedicalScribeJobName)))
            {
                WriteWarning("You are passing $null as a value for parameter MedicalScribeJobName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.TranscribeService.Model.GetMedicalScribeJobRequest();
            
            if (cmdletContext.MedicalScribeJobName != null)
            {
                request.MedicalScribeJobName = cmdletContext.MedicalScribeJobName;
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
        
        private Amazon.TranscribeService.Model.GetMedicalScribeJobResponse CallAWSServiceOperation(IAmazonTranscribeService client, Amazon.TranscribeService.Model.GetMedicalScribeJobRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Transcribe Service", "GetMedicalScribeJob");
            try
            {
                #if DESKTOP
                return client.GetMedicalScribeJob(request);
                #elif CORECLR
                return client.GetMedicalScribeJobAsync(request).GetAwaiter().GetResult();
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
            public System.String MedicalScribeJobName { get; set; }
            public System.Func<Amazon.TranscribeService.Model.GetMedicalScribeJobResponse, GetTRSMedicalScribeJobCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.MedicalScribeJob;
        }
        
    }
}
