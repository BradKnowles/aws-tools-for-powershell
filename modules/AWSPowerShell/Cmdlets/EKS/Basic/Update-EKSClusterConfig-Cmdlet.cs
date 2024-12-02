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
using Amazon.EKS;
using Amazon.EKS.Model;

namespace Amazon.PowerShell.Cmdlets.EKS
{
    /// <summary>
    /// Updates an Amazon EKS cluster configuration. Your cluster continues to function during
    /// the update. The response output includes an update ID that you can use to track the
    /// status of your cluster update with <c>DescribeUpdate</c>"/&gt;.
    /// 
    ///  
    /// <para>
    /// You can use this API operation to enable or disable exporting the Kubernetes control
    /// plane logs for your cluster to CloudWatch Logs. By default, cluster control plane
    /// logs aren't exported to CloudWatch Logs. For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/control-plane-logs.html">Amazon
    /// EKS Cluster control plane logs</a> in the <i><i>Amazon EKS User Guide</i></i>.
    /// </para><note><para>
    /// CloudWatch Logs ingestion, archive storage, and data scanning rates apply to exported
    /// control plane logs. For more information, see <a href="http://aws.amazon.com/cloudwatch/pricing/">CloudWatch
    /// Pricing</a>.
    /// </para></note><para>
    /// You can also use this API operation to enable or disable public and private access
    /// to your cluster's Kubernetes API server endpoint. By default, public access is enabled,
    /// and private access is disabled. For more information, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/cluster-endpoint.html">Amazon
    /// EKS cluster endpoint access control</a> in the <i><i>Amazon EKS User Guide</i></i>.
    /// </para><para>
    /// You can also use this API operation to choose different subnets and security groups
    /// for the cluster. You must specify at least two subnets that are in different Availability
    /// Zones. You can't change which VPC the subnets are from, the subnets must be in the
    /// same VPC as the subnets that the cluster was created with. For more information about
    /// the VPC requirements, see <a href="https://docs.aws.amazon.com/eks/latest/userguide/network_reqs.html">https://docs.aws.amazon.com/eks/latest/userguide/network_reqs.html</a>
    /// in the <i><i>Amazon EKS User Guide</i></i>.
    /// </para><para>
    /// You can also use this API operation to enable or disable ARC zonal shift. If zonal
    /// shift is enabled, Amazon Web Services configures zonal autoshift for the cluster.
    /// </para><para>
    /// Cluster updates are asynchronous, and they should finish within a few minutes. During
    /// an update, the cluster status moves to <c>UPDATING</c> (this status transition is
    /// eventually consistent). When the update is complete (either <c>Failed</c> or <c>Successful</c>),
    /// the cluster status moves to <c>Active</c>.
    /// </para>
    /// </summary>
    [Cmdlet("Update", "EKSClusterConfig", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.EKS.Model.Update")]
    [AWSCmdlet("Calls the Amazon Elastic Container Service for Kubernetes UpdateClusterConfig API operation.", Operation = new[] {"UpdateClusterConfig"}, SelectReturnType = typeof(Amazon.EKS.Model.UpdateClusterConfigResponse))]
    [AWSCmdletOutput("Amazon.EKS.Model.Update or Amazon.EKS.Model.UpdateClusterConfigResponse",
        "This cmdlet returns an Amazon.EKS.Model.Update object.",
        "The service call response (type Amazon.EKS.Model.UpdateClusterConfigResponse) can be returned by specifying '-Select *'."
    )]
    public partial class UpdateEKSClusterConfigCmdlet : AmazonEKSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter AccessConfig_AuthenticationMode
        /// <summary>
        /// <para>
        /// <para>The desired authentication mode for the cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EKS.AuthenticationMode")]
        public Amazon.EKS.AuthenticationMode AccessConfig_AuthenticationMode { get; set; }
        #endregion
        
        #region Parameter ClientRequestToken
        /// <summary>
        /// <para>
        /// <para>A unique, case-sensitive identifier that you provide to ensure the idempotency of
        /// the request.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ClientRequestToken { get; set; }
        #endregion
        
        #region Parameter Logging_ClusterLogging
        /// <summary>
        /// <para>
        /// <para>The cluster control plane logging configuration for your cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EKS.Model.LogSetup[] Logging_ClusterLogging { get; set; }
        #endregion
        
        #region Parameter ComputeConfig_Enabled
        /// <summary>
        /// <para>
        /// <para>Request to enable or disable the compute capability on your EKS Auto Mode cluster.
        /// If the compute capability is enabled, EKS Auto Mode will create and delete EC2 Managed
        /// Instances in your Amazon Web Services account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ComputeConfig_Enabled { get; set; }
        #endregion
        
        #region Parameter ElasticLoadBalancing_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates if the load balancing capability is enabled on your EKS Auto Mode cluster.
        /// If the load balancing capability is enabled, EKS Auto Mode will create and delete
        /// load balancers in your Amazon Web Services account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("KubernetesNetworkConfig_ElasticLoadBalancing_Enabled")]
        public System.Boolean? ElasticLoadBalancing_Enabled { get; set; }
        #endregion
        
        #region Parameter BlockStorage_Enabled
        /// <summary>
        /// <para>
        /// <para>Indicates if the block storage capability is enabled on your EKS Auto Mode cluster.
        /// If the block storage capability is enabled, EKS Auto Mode will create and delete EBS
        /// volumes in your Amazon Web Services account.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("StorageConfig_BlockStorage_Enabled")]
        public System.Boolean? BlockStorage_Enabled { get; set; }
        #endregion
        
        #region Parameter ZonalShiftConfig_Enabled
        /// <summary>
        /// <para>
        /// <para>If zonal shift is enabled, Amazon Web Services configures zonal autoshift for the
        /// cluster.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ZonalShiftConfig_Enabled { get; set; }
        #endregion
        
        #region Parameter KubernetesNetworkConfig_IpFamily
        /// <summary>
        /// <para>
        /// <para>Specify which IP family is used to assign Kubernetes pod and service IP addresses.
        /// If you don't specify a value, <c>ipv4</c> is used by default. You can only specify
        /// an IP family when you create a cluster and can't change this value once the cluster
        /// is created. If you specify <c>ipv6</c>, the VPC and subnets that you specify for cluster
        /// creation must have both <c>IPv4</c> and <c>IPv6</c> CIDR blocks assigned to them.
        /// You can't specify <c>ipv6</c> for clusters in China Regions.</para><para>You can only specify <c>ipv6</c> for <c>1.21</c> and later clusters that use version
        /// <c>1.10.1</c> or later of the Amazon VPC CNI add-on. If you specify <c>ipv6</c>, then
        /// ensure that your VPC meets the requirements listed in the considerations listed in
        /// <a href="https://docs.aws.amazon.com/eks/latest/userguide/cni-ipv6.html">Assigning
        /// IPv6 addresses to pods and services</a> in the Amazon EKS User Guide. Kubernetes assigns
        /// services <c>IPv6</c> addresses from the unique local address range <c>(fc00::/7)</c>.
        /// You can't specify a custom <c>IPv6</c> CIDR block. Pod addresses are assigned from
        /// the subnet's <c>IPv6</c> CIDR.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EKS.IpFamily")]
        public Amazon.EKS.IpFamily KubernetesNetworkConfig_IpFamily { get; set; }
        #endregion
        
        #region Parameter Name
        /// <summary>
        /// <para>
        /// <para>The name of the Amazon EKS cluster to update.</para>
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
        public System.String Name { get; set; }
        #endregion
        
        #region Parameter ComputeConfig_NodePool
        /// <summary>
        /// <para>
        /// <para>Configuration for node pools that defines the compute resources for your EKS Auto
        /// Mode cluster. For more information, see EKS Auto Mode Node Pools in the EKS User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ComputeConfig_NodePools")]
        public System.String[] ComputeConfig_NodePool { get; set; }
        #endregion
        
        #region Parameter ComputeConfig_NodeRoleArn
        /// <summary>
        /// <para>
        /// <para>The ARN of the IAM Role EKS will assign to EC2 Managed Instances in your EKS Auto
        /// Mode cluster. This value cannot be changed after the compute capability of EKS Auto
        /// Mode is enabled. For more information, see the IAM Reference in the EKS User Guide.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ComputeConfig_NodeRoleArn { get; set; }
        #endregion
        
        #region Parameter ResourcesVpcConfig
        /// <summary>
        /// <para>
        /// The service has not provided documentation for this parameter; please refer to the service's API reference documentation for the latest available information.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.EKS.Model.VpcConfigRequest ResourcesVpcConfig { get; set; }
        #endregion
        
        #region Parameter KubernetesNetworkConfig_ServiceIpv4Cidr
        /// <summary>
        /// <para>
        /// <para>Don't specify a value if you select <c>ipv6</c> for <b>ipFamily</b>. The CIDR block
        /// to assign Kubernetes service IP addresses from. If you don't specify a block, Kubernetes
        /// assigns addresses from either the <c>10.100.0.0/16</c> or <c>172.20.0.0/16</c> CIDR
        /// blocks. We recommend that you specify a block that does not overlap with resources
        /// in other networks that are peered or connected to your VPC. The block must meet the
        /// following requirements:</para><ul><li><para>Within one of the following private IP address blocks: <c>10.0.0.0/8</c>, <c>172.16.0.0/12</c>,
        /// or <c>192.168.0.0/16</c>.</para></li><li><para>Doesn't overlap with any CIDR block assigned to the VPC that you selected for VPC.</para></li><li><para>Between <c>/24</c> and <c>/12</c>.</para></li></ul><important><para>You can only specify a custom CIDR block when you create a cluster. You can't change
        /// this value after the cluster is created.</para></important>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String KubernetesNetworkConfig_ServiceIpv4Cidr { get; set; }
        #endregion
        
        #region Parameter UpgradePolicy_SupportType
        /// <summary>
        /// <para>
        /// <para>If the cluster is set to <c>EXTENDED</c>, it will enter extended support at the end
        /// of standard support. If the cluster is set to <c>STANDARD</c>, it will be automatically
        /// upgraded at the end of standard support.</para><para><a href="https://docs.aws.amazon.com/eks/latest/userguide/extended-support-control.html">Learn
        /// more about EKS Extended Support in the EKS User Guide.</a></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.EKS.SupportType")]
        public Amazon.EKS.SupportType UpgradePolicy_SupportType { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Update'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.EKS.Model.UpdateClusterConfigResponse).
        /// Specifying the name of a property of type Amazon.EKS.Model.UpdateClusterConfigResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Update";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Name parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Name' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Name), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EKSClusterConfig (UpdateClusterConfig)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.EKS.Model.UpdateClusterConfigResponse, UpdateEKSClusterConfigCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Name;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.AccessConfig_AuthenticationMode = this.AccessConfig_AuthenticationMode;
            context.ClientRequestToken = this.ClientRequestToken;
            context.ComputeConfig_Enabled = this.ComputeConfig_Enabled;
            if (this.ComputeConfig_NodePool != null)
            {
                context.ComputeConfig_NodePool = new List<System.String>(this.ComputeConfig_NodePool);
            }
            context.ComputeConfig_NodeRoleArn = this.ComputeConfig_NodeRoleArn;
            context.ElasticLoadBalancing_Enabled = this.ElasticLoadBalancing_Enabled;
            context.KubernetesNetworkConfig_IpFamily = this.KubernetesNetworkConfig_IpFamily;
            context.KubernetesNetworkConfig_ServiceIpv4Cidr = this.KubernetesNetworkConfig_ServiceIpv4Cidr;
            if (this.Logging_ClusterLogging != null)
            {
                context.Logging_ClusterLogging = new List<Amazon.EKS.Model.LogSetup>(this.Logging_ClusterLogging);
            }
            context.Name = this.Name;
            #if MODULAR
            if (this.Name == null && ParameterWasBound(nameof(this.Name)))
            {
                WriteWarning("You are passing $null as a value for parameter Name which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ResourcesVpcConfig = this.ResourcesVpcConfig;
            context.BlockStorage_Enabled = this.BlockStorage_Enabled;
            context.UpgradePolicy_SupportType = this.UpgradePolicy_SupportType;
            context.ZonalShiftConfig_Enabled = this.ZonalShiftConfig_Enabled;
            
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
            var request = new Amazon.EKS.Model.UpdateClusterConfigRequest();
            
            
             // populate AccessConfig
            var requestAccessConfigIsNull = true;
            request.AccessConfig = new Amazon.EKS.Model.UpdateAccessConfigRequest();
            Amazon.EKS.AuthenticationMode requestAccessConfig_accessConfig_AuthenticationMode = null;
            if (cmdletContext.AccessConfig_AuthenticationMode != null)
            {
                requestAccessConfig_accessConfig_AuthenticationMode = cmdletContext.AccessConfig_AuthenticationMode;
            }
            if (requestAccessConfig_accessConfig_AuthenticationMode != null)
            {
                request.AccessConfig.AuthenticationMode = requestAccessConfig_accessConfig_AuthenticationMode;
                requestAccessConfigIsNull = false;
            }
             // determine if request.AccessConfig should be set to null
            if (requestAccessConfigIsNull)
            {
                request.AccessConfig = null;
            }
            if (cmdletContext.ClientRequestToken != null)
            {
                request.ClientRequestToken = cmdletContext.ClientRequestToken;
            }
            
             // populate ComputeConfig
            var requestComputeConfigIsNull = true;
            request.ComputeConfig = new Amazon.EKS.Model.ComputeConfigRequest();
            System.Boolean? requestComputeConfig_computeConfig_Enabled = null;
            if (cmdletContext.ComputeConfig_Enabled != null)
            {
                requestComputeConfig_computeConfig_Enabled = cmdletContext.ComputeConfig_Enabled.Value;
            }
            if (requestComputeConfig_computeConfig_Enabled != null)
            {
                request.ComputeConfig.Enabled = requestComputeConfig_computeConfig_Enabled.Value;
                requestComputeConfigIsNull = false;
            }
            List<System.String> requestComputeConfig_computeConfig_NodePool = null;
            if (cmdletContext.ComputeConfig_NodePool != null)
            {
                requestComputeConfig_computeConfig_NodePool = cmdletContext.ComputeConfig_NodePool;
            }
            if (requestComputeConfig_computeConfig_NodePool != null)
            {
                request.ComputeConfig.NodePools = requestComputeConfig_computeConfig_NodePool;
                requestComputeConfigIsNull = false;
            }
            System.String requestComputeConfig_computeConfig_NodeRoleArn = null;
            if (cmdletContext.ComputeConfig_NodeRoleArn != null)
            {
                requestComputeConfig_computeConfig_NodeRoleArn = cmdletContext.ComputeConfig_NodeRoleArn;
            }
            if (requestComputeConfig_computeConfig_NodeRoleArn != null)
            {
                request.ComputeConfig.NodeRoleArn = requestComputeConfig_computeConfig_NodeRoleArn;
                requestComputeConfigIsNull = false;
            }
             // determine if request.ComputeConfig should be set to null
            if (requestComputeConfigIsNull)
            {
                request.ComputeConfig = null;
            }
            
             // populate KubernetesNetworkConfig
            var requestKubernetesNetworkConfigIsNull = true;
            request.KubernetesNetworkConfig = new Amazon.EKS.Model.KubernetesNetworkConfigRequest();
            Amazon.EKS.IpFamily requestKubernetesNetworkConfig_kubernetesNetworkConfig_IpFamily = null;
            if (cmdletContext.KubernetesNetworkConfig_IpFamily != null)
            {
                requestKubernetesNetworkConfig_kubernetesNetworkConfig_IpFamily = cmdletContext.KubernetesNetworkConfig_IpFamily;
            }
            if (requestKubernetesNetworkConfig_kubernetesNetworkConfig_IpFamily != null)
            {
                request.KubernetesNetworkConfig.IpFamily = requestKubernetesNetworkConfig_kubernetesNetworkConfig_IpFamily;
                requestKubernetesNetworkConfigIsNull = false;
            }
            System.String requestKubernetesNetworkConfig_kubernetesNetworkConfig_ServiceIpv4Cidr = null;
            if (cmdletContext.KubernetesNetworkConfig_ServiceIpv4Cidr != null)
            {
                requestKubernetesNetworkConfig_kubernetesNetworkConfig_ServiceIpv4Cidr = cmdletContext.KubernetesNetworkConfig_ServiceIpv4Cidr;
            }
            if (requestKubernetesNetworkConfig_kubernetesNetworkConfig_ServiceIpv4Cidr != null)
            {
                request.KubernetesNetworkConfig.ServiceIpv4Cidr = requestKubernetesNetworkConfig_kubernetesNetworkConfig_ServiceIpv4Cidr;
                requestKubernetesNetworkConfigIsNull = false;
            }
            Amazon.EKS.Model.ElasticLoadBalancing requestKubernetesNetworkConfig_kubernetesNetworkConfig_ElasticLoadBalancing = null;
            
             // populate ElasticLoadBalancing
            var requestKubernetesNetworkConfig_kubernetesNetworkConfig_ElasticLoadBalancingIsNull = true;
            requestKubernetesNetworkConfig_kubernetesNetworkConfig_ElasticLoadBalancing = new Amazon.EKS.Model.ElasticLoadBalancing();
            System.Boolean? requestKubernetesNetworkConfig_kubernetesNetworkConfig_ElasticLoadBalancing_elasticLoadBalancing_Enabled = null;
            if (cmdletContext.ElasticLoadBalancing_Enabled != null)
            {
                requestKubernetesNetworkConfig_kubernetesNetworkConfig_ElasticLoadBalancing_elasticLoadBalancing_Enabled = cmdletContext.ElasticLoadBalancing_Enabled.Value;
            }
            if (requestKubernetesNetworkConfig_kubernetesNetworkConfig_ElasticLoadBalancing_elasticLoadBalancing_Enabled != null)
            {
                requestKubernetesNetworkConfig_kubernetesNetworkConfig_ElasticLoadBalancing.Enabled = requestKubernetesNetworkConfig_kubernetesNetworkConfig_ElasticLoadBalancing_elasticLoadBalancing_Enabled.Value;
                requestKubernetesNetworkConfig_kubernetesNetworkConfig_ElasticLoadBalancingIsNull = false;
            }
             // determine if requestKubernetesNetworkConfig_kubernetesNetworkConfig_ElasticLoadBalancing should be set to null
            if (requestKubernetesNetworkConfig_kubernetesNetworkConfig_ElasticLoadBalancingIsNull)
            {
                requestKubernetesNetworkConfig_kubernetesNetworkConfig_ElasticLoadBalancing = null;
            }
            if (requestKubernetesNetworkConfig_kubernetesNetworkConfig_ElasticLoadBalancing != null)
            {
                request.KubernetesNetworkConfig.ElasticLoadBalancing = requestKubernetesNetworkConfig_kubernetesNetworkConfig_ElasticLoadBalancing;
                requestKubernetesNetworkConfigIsNull = false;
            }
             // determine if request.KubernetesNetworkConfig should be set to null
            if (requestKubernetesNetworkConfigIsNull)
            {
                request.KubernetesNetworkConfig = null;
            }
            
             // populate Logging
            var requestLoggingIsNull = true;
            request.Logging = new Amazon.EKS.Model.Logging();
            List<Amazon.EKS.Model.LogSetup> requestLogging_logging_ClusterLogging = null;
            if (cmdletContext.Logging_ClusterLogging != null)
            {
                requestLogging_logging_ClusterLogging = cmdletContext.Logging_ClusterLogging;
            }
            if (requestLogging_logging_ClusterLogging != null)
            {
                request.Logging.ClusterLogging = requestLogging_logging_ClusterLogging;
                requestLoggingIsNull = false;
            }
             // determine if request.Logging should be set to null
            if (requestLoggingIsNull)
            {
                request.Logging = null;
            }
            if (cmdletContext.Name != null)
            {
                request.Name = cmdletContext.Name;
            }
            if (cmdletContext.ResourcesVpcConfig != null)
            {
                request.ResourcesVpcConfig = cmdletContext.ResourcesVpcConfig;
            }
            
             // populate StorageConfig
            var requestStorageConfigIsNull = true;
            request.StorageConfig = new Amazon.EKS.Model.StorageConfigRequest();
            Amazon.EKS.Model.BlockStorage requestStorageConfig_storageConfig_BlockStorage = null;
            
             // populate BlockStorage
            var requestStorageConfig_storageConfig_BlockStorageIsNull = true;
            requestStorageConfig_storageConfig_BlockStorage = new Amazon.EKS.Model.BlockStorage();
            System.Boolean? requestStorageConfig_storageConfig_BlockStorage_blockStorage_Enabled = null;
            if (cmdletContext.BlockStorage_Enabled != null)
            {
                requestStorageConfig_storageConfig_BlockStorage_blockStorage_Enabled = cmdletContext.BlockStorage_Enabled.Value;
            }
            if (requestStorageConfig_storageConfig_BlockStorage_blockStorage_Enabled != null)
            {
                requestStorageConfig_storageConfig_BlockStorage.Enabled = requestStorageConfig_storageConfig_BlockStorage_blockStorage_Enabled.Value;
                requestStorageConfig_storageConfig_BlockStorageIsNull = false;
            }
             // determine if requestStorageConfig_storageConfig_BlockStorage should be set to null
            if (requestStorageConfig_storageConfig_BlockStorageIsNull)
            {
                requestStorageConfig_storageConfig_BlockStorage = null;
            }
            if (requestStorageConfig_storageConfig_BlockStorage != null)
            {
                request.StorageConfig.BlockStorage = requestStorageConfig_storageConfig_BlockStorage;
                requestStorageConfigIsNull = false;
            }
             // determine if request.StorageConfig should be set to null
            if (requestStorageConfigIsNull)
            {
                request.StorageConfig = null;
            }
            
             // populate UpgradePolicy
            var requestUpgradePolicyIsNull = true;
            request.UpgradePolicy = new Amazon.EKS.Model.UpgradePolicyRequest();
            Amazon.EKS.SupportType requestUpgradePolicy_upgradePolicy_SupportType = null;
            if (cmdletContext.UpgradePolicy_SupportType != null)
            {
                requestUpgradePolicy_upgradePolicy_SupportType = cmdletContext.UpgradePolicy_SupportType;
            }
            if (requestUpgradePolicy_upgradePolicy_SupportType != null)
            {
                request.UpgradePolicy.SupportType = requestUpgradePolicy_upgradePolicy_SupportType;
                requestUpgradePolicyIsNull = false;
            }
             // determine if request.UpgradePolicy should be set to null
            if (requestUpgradePolicyIsNull)
            {
                request.UpgradePolicy = null;
            }
            
             // populate ZonalShiftConfig
            var requestZonalShiftConfigIsNull = true;
            request.ZonalShiftConfig = new Amazon.EKS.Model.ZonalShiftConfigRequest();
            System.Boolean? requestZonalShiftConfig_zonalShiftConfig_Enabled = null;
            if (cmdletContext.ZonalShiftConfig_Enabled != null)
            {
                requestZonalShiftConfig_zonalShiftConfig_Enabled = cmdletContext.ZonalShiftConfig_Enabled.Value;
            }
            if (requestZonalShiftConfig_zonalShiftConfig_Enabled != null)
            {
                request.ZonalShiftConfig.Enabled = requestZonalShiftConfig_zonalShiftConfig_Enabled.Value;
                requestZonalShiftConfigIsNull = false;
            }
             // determine if request.ZonalShiftConfig should be set to null
            if (requestZonalShiftConfigIsNull)
            {
                request.ZonalShiftConfig = null;
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
        
        private Amazon.EKS.Model.UpdateClusterConfigResponse CallAWSServiceOperation(IAmazonEKS client, Amazon.EKS.Model.UpdateClusterConfigRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon Elastic Container Service for Kubernetes", "UpdateClusterConfig");
            try
            {
                #if DESKTOP
                return client.UpdateClusterConfig(request);
                #elif CORECLR
                return client.UpdateClusterConfigAsync(request).GetAwaiter().GetResult();
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
            public Amazon.EKS.AuthenticationMode AccessConfig_AuthenticationMode { get; set; }
            public System.String ClientRequestToken { get; set; }
            public System.Boolean? ComputeConfig_Enabled { get; set; }
            public List<System.String> ComputeConfig_NodePool { get; set; }
            public System.String ComputeConfig_NodeRoleArn { get; set; }
            public System.Boolean? ElasticLoadBalancing_Enabled { get; set; }
            public Amazon.EKS.IpFamily KubernetesNetworkConfig_IpFamily { get; set; }
            public System.String KubernetesNetworkConfig_ServiceIpv4Cidr { get; set; }
            public List<Amazon.EKS.Model.LogSetup> Logging_ClusterLogging { get; set; }
            public System.String Name { get; set; }
            public Amazon.EKS.Model.VpcConfigRequest ResourcesVpcConfig { get; set; }
            public System.Boolean? BlockStorage_Enabled { get; set; }
            public Amazon.EKS.SupportType UpgradePolicy_SupportType { get; set; }
            public System.Boolean? ZonalShiftConfig_Enabled { get; set; }
            public System.Func<Amazon.EKS.Model.UpdateClusterConfigResponse, UpdateEKSClusterConfigCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Update;
        }
        
    }
}
