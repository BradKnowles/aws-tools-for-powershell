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
using Amazon.EntityResolution;
using Amazon.EntityResolution.Model;

namespace Amazon.PowerShell.Cmdlets.ERES
{
    /// <summary>
    /// Updates an existing <c>IdMappingWorkflow</c>. This method is identical to <c>CreateIdMappingWorkflow</c>,
    /// except it uses an HTTP <c>PUT</c> request instead of a <c>POST</c> request, and the
    /// <c>IdMappingWorkflow</c> must already exist for the method to succeed.
    /// </summary>
    [Cmdlet("Update", "ERESIdMappingWorkflow", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EntityResolution.Model.UpdateIdMappingWorkflowResponse")]
    [AWSCmdlet("Calls the AWS EntityResolution UpdateIdMappingWorkflow API operation.", Operation = new[] {"UpdateIdMappingWorkflow"}, SelectReturnType = typeof(Amazon.EntityResolution.Model.UpdateIdMappingWorkflowResponse))]
    [AWSCmdletOutput("Amazon.EntityResolution.Model.UpdateIdMappingWorkflowResponse",
        "This cmdlet returns an Amazon.EntityResolution.Model.UpdateIdMappingWorkflowResponse object containing multiple properties. The object can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateERESIdMappingWorkflowCmdlet : AmazonEntityResolutionClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// <para>A description of the workflow.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter IdMappingTechniques_IdMappingType
        /// <summary>
        /// <para>
        /// <para>The type of ID mapping.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        [AWSConstantClassSource("Amazon.EntityResolution.IdMappingType")]
        public Amazon.EntityResolution.IdMappingType IdMappingTechniques_IdMappingType { get; set; }
        #endregion
        
        #region Parameter InputSourceConfig
        /// <summary>
        /// <para>
        /// <para>A list of <c>InputSource</c> objects, which have the fields <c>InputSourceARN</c>
        /// and <c>SchemaName</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.EntityResolution.Model.IdMappingWorkflowInputSource[] InputSourceConfig { get; set; }
        #endregion
        
        #region Parameter IntermediateSourceConfiguration_IntermediateS3Path
        /// <summary>
        /// <para>
        /// <para>The Amazon S3 location (bucket and prefix). For example: <c>s3://provider_bucket/DOC-EXAMPLE-BUCKET</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdMappingTechniques_ProviderProperties_IntermediateSourceConfiguration_IntermediateS3Path")]
        public System.String IntermediateSourceConfiguration_IntermediateS3Path { get; set; }
        #endregion
        
        #region Parameter OutputSourceConfig
        /// <summary>
        /// <para>
        /// <para>A list of <c>OutputSource</c> objects, each of which contains fields <c>OutputS3Path</c>
        /// and <c>KMSArn</c>.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyCollection]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public Amazon.EntityResolution.Model.IdMappingWorkflowOutputSource[] OutputSourceConfig { get; set; }
        #endregion
        
        #region Parameter ProviderProperties_ProviderConfiguration
        /// <summary>
        /// <para>
        /// <para>The required configuration fields to use with the provider service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("IdMappingTechniques_ProviderProperties_ProviderConfiguration")]
        public System.Management.Automation.PSObject ProviderProperties_ProviderConfiguration { get; set; }
        #endregion
        
        #region Parameter ProviderProperties_ProviderServiceArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the provider service.</para>
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
        [Alias("IdMappingTechniques_ProviderProperties_ProviderServiceArn")]
        public System.String ProviderProperties_ProviderServiceArn { get; set; }
        #endregion
        
        #region Parameter RoleArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) of the IAM role. Entity Resolution assumes this role
        /// to access resources on your behalf.</para>
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
        public System.String RoleArn { get; set; }
        #endregion
        
        #region Parameter WorkflowName
        /// <summary>
        /// <para>
        /// <para>The name of the workflow.</para>
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
        public System.String WorkflowName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is '*'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EntityResolution.Model.UpdateIdMappingWorkflowResponse).
        /// Specifying the name of a property of type Amazon.EntityResolution.Model.UpdateIdMappingWorkflowResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "*";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the WorkflowName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^WorkflowName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^WorkflowName' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.WorkflowName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ERESIdMappingWorkflow (UpdateIdMappingWorkflow)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EntityResolution.Model.UpdateIdMappingWorkflowResponse, UpdateERESIdMappingWorkflowCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.WorkflowName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.Description = this.Description;
            context.IdMappingTechniques_IdMappingType = this.IdMappingTechniques_IdMappingType;
            #if MODULAR
            if (this.IdMappingTechniques_IdMappingType == null && ParameterWasBound(nameof(this.IdMappingTechniques_IdMappingType)))
            {
                WriteWarning("You are passing $null as a value for parameter IdMappingTechniques_IdMappingType which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.IntermediateSourceConfiguration_IntermediateS3Path = this.IntermediateSourceConfiguration_IntermediateS3Path;
            context.ProviderProperties_ProviderConfiguration = this.ProviderProperties_ProviderConfiguration;
            context.ProviderProperties_ProviderServiceArn = this.ProviderProperties_ProviderServiceArn;
            #if MODULAR
            if (this.ProviderProperties_ProviderServiceArn == null && ParameterWasBound(nameof(this.ProviderProperties_ProviderServiceArn)))
            {
                WriteWarning("You are passing $null as a value for parameter ProviderProperties_ProviderServiceArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.InputSourceConfig != null)
            {
                context.InputSourceConfig = new List<Amazon.EntityResolution.Model.IdMappingWorkflowInputSource>(this.InputSourceConfig);
            }
            #if MODULAR
            if (this.InputSourceConfig == null && ParameterWasBound(nameof(this.InputSourceConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter InputSourceConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            if (this.OutputSourceConfig != null)
            {
                context.OutputSourceConfig = new List<Amazon.EntityResolution.Model.IdMappingWorkflowOutputSource>(this.OutputSourceConfig);
            }
            #if MODULAR
            if (this.OutputSourceConfig == null && ParameterWasBound(nameof(this.OutputSourceConfig)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputSourceConfig which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.RoleArn = this.RoleArn;
            #if MODULAR
            if (this.RoleArn == null && ParameterWasBound(nameof(this.RoleArn)))
            {
                WriteWarning("You are passing $null as a value for parameter RoleArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.WorkflowName = this.WorkflowName;
            #if MODULAR
            if (this.WorkflowName == null && ParameterWasBound(nameof(this.WorkflowName)))
            {
                WriteWarning("You are passing $null as a value for parameter WorkflowName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
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
            var request = new Amazon.EntityResolution.Model.UpdateIdMappingWorkflowRequest();
            
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            
             // populate IdMappingTechniques
            var requestIdMappingTechniquesIsNull = true;
            request.IdMappingTechniques = new Amazon.EntityResolution.Model.IdMappingTechniques();
            Amazon.EntityResolution.IdMappingType requestIdMappingTechniques_idMappingTechniques_IdMappingType = null;
            if (cmdletContext.IdMappingTechniques_IdMappingType != null)
            {
                requestIdMappingTechniques_idMappingTechniques_IdMappingType = cmdletContext.IdMappingTechniques_IdMappingType;
            }
            if (requestIdMappingTechniques_idMappingTechniques_IdMappingType != null)
            {
                request.IdMappingTechniques.IdMappingType = requestIdMappingTechniques_idMappingTechniques_IdMappingType;
                requestIdMappingTechniquesIsNull = false;
            }
            Amazon.EntityResolution.Model.ProviderProperties requestIdMappingTechniques_idMappingTechniques_ProviderProperties = null;
            
             // populate ProviderProperties
            var requestIdMappingTechniques_idMappingTechniques_ProviderPropertiesIsNull = true;
            requestIdMappingTechniques_idMappingTechniques_ProviderProperties = new Amazon.EntityResolution.Model.ProviderProperties();
            Amazon.Runtime.Documents.Document? requestIdMappingTechniques_idMappingTechniques_ProviderProperties_providerProperties_ProviderConfiguration = null;
            if (cmdletContext.ProviderProperties_ProviderConfiguration != null)
            {
                requestIdMappingTechniques_idMappingTechniques_ProviderProperties_providerProperties_ProviderConfiguration = Amazon.PowerShell.Common.DocumentHelper.ToDocument(cmdletContext.ProviderProperties_ProviderConfiguration);
            }
            if (requestIdMappingTechniques_idMappingTechniques_ProviderProperties_providerProperties_ProviderConfiguration != null)
            {
                requestIdMappingTechniques_idMappingTechniques_ProviderProperties.ProviderConfiguration = requestIdMappingTechniques_idMappingTechniques_ProviderProperties_providerProperties_ProviderConfiguration.Value;
                requestIdMappingTechniques_idMappingTechniques_ProviderPropertiesIsNull = false;
            }
            System.String requestIdMappingTechniques_idMappingTechniques_ProviderProperties_providerProperties_ProviderServiceArn = null;
            if (cmdletContext.ProviderProperties_ProviderServiceArn != null)
            {
                requestIdMappingTechniques_idMappingTechniques_ProviderProperties_providerProperties_ProviderServiceArn = cmdletContext.ProviderProperties_ProviderServiceArn;
            }
            if (requestIdMappingTechniques_idMappingTechniques_ProviderProperties_providerProperties_ProviderServiceArn != null)
            {
                requestIdMappingTechniques_idMappingTechniques_ProviderProperties.ProviderServiceArn = requestIdMappingTechniques_idMappingTechniques_ProviderProperties_providerProperties_ProviderServiceArn;
                requestIdMappingTechniques_idMappingTechniques_ProviderPropertiesIsNull = false;
            }
            Amazon.EntityResolution.Model.IntermediateSourceConfiguration requestIdMappingTechniques_idMappingTechniques_ProviderProperties_idMappingTechniques_ProviderProperties_IntermediateSourceConfiguration = null;
            
             // populate IntermediateSourceConfiguration
            var requestIdMappingTechniques_idMappingTechniques_ProviderProperties_idMappingTechniques_ProviderProperties_IntermediateSourceConfigurationIsNull = true;
            requestIdMappingTechniques_idMappingTechniques_ProviderProperties_idMappingTechniques_ProviderProperties_IntermediateSourceConfiguration = new Amazon.EntityResolution.Model.IntermediateSourceConfiguration();
            System.String requestIdMappingTechniques_idMappingTechniques_ProviderProperties_idMappingTechniques_ProviderProperties_IntermediateSourceConfiguration_intermediateSourceConfiguration_IntermediateS3Path = null;
            if (cmdletContext.IntermediateSourceConfiguration_IntermediateS3Path != null)
            {
                requestIdMappingTechniques_idMappingTechniques_ProviderProperties_idMappingTechniques_ProviderProperties_IntermediateSourceConfiguration_intermediateSourceConfiguration_IntermediateS3Path = cmdletContext.IntermediateSourceConfiguration_IntermediateS3Path;
            }
            if (requestIdMappingTechniques_idMappingTechniques_ProviderProperties_idMappingTechniques_ProviderProperties_IntermediateSourceConfiguration_intermediateSourceConfiguration_IntermediateS3Path != null)
            {
                requestIdMappingTechniques_idMappingTechniques_ProviderProperties_idMappingTechniques_ProviderProperties_IntermediateSourceConfiguration.IntermediateS3Path = requestIdMappingTechniques_idMappingTechniques_ProviderProperties_idMappingTechniques_ProviderProperties_IntermediateSourceConfiguration_intermediateSourceConfiguration_IntermediateS3Path;
                requestIdMappingTechniques_idMappingTechniques_ProviderProperties_idMappingTechniques_ProviderProperties_IntermediateSourceConfigurationIsNull = false;
            }
             // determine if requestIdMappingTechniques_idMappingTechniques_ProviderProperties_idMappingTechniques_ProviderProperties_IntermediateSourceConfiguration should be set to null
            if (requestIdMappingTechniques_idMappingTechniques_ProviderProperties_idMappingTechniques_ProviderProperties_IntermediateSourceConfigurationIsNull)
            {
                requestIdMappingTechniques_idMappingTechniques_ProviderProperties_idMappingTechniques_ProviderProperties_IntermediateSourceConfiguration = null;
            }
            if (requestIdMappingTechniques_idMappingTechniques_ProviderProperties_idMappingTechniques_ProviderProperties_IntermediateSourceConfiguration != null)
            {
                requestIdMappingTechniques_idMappingTechniques_ProviderProperties.IntermediateSourceConfiguration = requestIdMappingTechniques_idMappingTechniques_ProviderProperties_idMappingTechniques_ProviderProperties_IntermediateSourceConfiguration;
                requestIdMappingTechniques_idMappingTechniques_ProviderPropertiesIsNull = false;
            }
             // determine if requestIdMappingTechniques_idMappingTechniques_ProviderProperties should be set to null
            if (requestIdMappingTechniques_idMappingTechniques_ProviderPropertiesIsNull)
            {
                requestIdMappingTechniques_idMappingTechniques_ProviderProperties = null;
            }
            if (requestIdMappingTechniques_idMappingTechniques_ProviderProperties != null)
            {
                request.IdMappingTechniques.ProviderProperties = requestIdMappingTechniques_idMappingTechniques_ProviderProperties;
                requestIdMappingTechniquesIsNull = false;
            }
             // determine if request.IdMappingTechniques should be set to null
            if (requestIdMappingTechniquesIsNull)
            {
                request.IdMappingTechniques = null;
            }
            if (cmdletContext.InputSourceConfig != null)
            {
                request.InputSourceConfig = cmdletContext.InputSourceConfig;
            }
            if (cmdletContext.OutputSourceConfig != null)
            {
                request.OutputSourceConfig = cmdletContext.OutputSourceConfig;
            }
            if (cmdletContext.RoleArn != null)
            {
                request.RoleArn = cmdletContext.RoleArn;
            }
            if (cmdletContext.WorkflowName != null)
            {
                request.WorkflowName = cmdletContext.WorkflowName;
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
        
        private Amazon.EntityResolution.Model.UpdateIdMappingWorkflowResponse CallAWSServiceOperation(IAmazonEntityResolution client, Amazon.EntityResolution.Model.UpdateIdMappingWorkflowRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS EntityResolution", "UpdateIdMappingWorkflow");
            try
            {
                #if DESKTOP
                return client.UpdateIdMappingWorkflow(request);
                #elif CORECLR
                return client.UpdateIdMappingWorkflowAsync(request).GetAwaiter().GetResult();
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
            public System.String Description { get; set; }
            public Amazon.EntityResolution.IdMappingType IdMappingTechniques_IdMappingType { get; set; }
            public System.String IntermediateSourceConfiguration_IntermediateS3Path { get; set; }
            public System.Management.Automation.PSObject ProviderProperties_ProviderConfiguration { get; set; }
            public System.String ProviderProperties_ProviderServiceArn { get; set; }
            public List<Amazon.EntityResolution.Model.IdMappingWorkflowInputSource> InputSourceConfig { get; set; }
            public List<Amazon.EntityResolution.Model.IdMappingWorkflowOutputSource> OutputSourceConfig { get; set; }
            public System.String RoleArn { get; set; }
            public System.String WorkflowName { get; set; }
            public System.Func<Amazon.EntityResolution.Model.UpdateIdMappingWorkflowResponse, UpdateERESIdMappingWorkflowCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response;
        }
        
    }
}
