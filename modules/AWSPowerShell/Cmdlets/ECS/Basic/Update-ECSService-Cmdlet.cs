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
using Amazon.ECS;
using Amazon.ECS.Model;

namespace Amazon.PowerShell.Cmdlets.ECS
{
    /// <summary>
    /// Modifies the parameters of a service.
    /// 
    ///  
    /// <para>
    /// For services using the rolling update (<c>ECS</c>) you can update the desired count,
    /// deployment configuration, network configuration, load balancers, service registries,
    /// enable ECS managed tags option, propagate tags option, task placement constraints
    /// and strategies, and task definition. When you update any of these parameters, Amazon
    /// ECS starts new tasks with the new configuration. 
    /// </para><para>
    /// For services using the blue/green (<c>CODE_DEPLOY</c>) deployment controller, only
    /// the desired count, deployment configuration, health check grace period, task placement
    /// constraints and strategies, enable ECS managed tags option, and propagate tags can
    /// be updated using this API. If the network configuration, platform version, task definition,
    /// or load balancer need to be updated, create a new CodeDeploy deployment. For more
    /// information, see <a href="https://docs.aws.amazon.com/codedeploy/latest/APIReference/API_CreateDeployment.html">CreateDeployment</a>
    /// in the <i>CodeDeploy API Reference</i>.
    /// </para><para>
    /// For services using an external deployment controller, you can update only the desired
    /// count, task placement constraints and strategies, health check grace period, enable
    /// ECS managed tags option, and propagate tags option, using this API. If the launch
    /// type, load balancer, network configuration, platform version, or task definition need
    /// to be updated, create a new task set For more information, see <a>CreateTaskSet</a>.
    /// </para><para>
    /// You can add to or subtract from the number of instantiations of a task definition
    /// in a service by specifying the cluster that the service is running in and a new <c>desiredCount</c>
    /// parameter.
    /// </para><para>
    /// If you have updated the Docker image of your application, you can create a new task
    /// definition with that image and deploy it to your service. The service scheduler uses
    /// the minimum healthy percent and maximum percent parameters (in the service's deployment
    /// configuration) to determine the deployment strategy.
    /// </para><note><para>
    /// If your updated Docker image uses the same tag as what is in the existing task definition
    /// for your service (for example, <c>my_image:latest</c>), you don't need to create a
    /// new revision of your task definition. You can update the service using the <c>forceNewDeployment</c>
    /// option. The new tasks launched by the deployment pull the current image/tag combination
    /// from your repository when they start.
    /// </para></note><para>
    /// You can also update the deployment configuration of a service. When a deployment is
    /// triggered by updating the task definition of a service, the service scheduler uses
    /// the deployment configuration parameters, <c>minimumHealthyPercent</c> and <c>maximumPercent</c>,
    /// to determine the deployment strategy.
    /// </para><ul><li><para>
    /// If <c>minimumHealthyPercent</c> is below 100%, the scheduler can ignore <c>desiredCount</c>
    /// temporarily during a deployment. For example, if <c>desiredCount</c> is four tasks,
    /// a minimum of 50% allows the scheduler to stop two existing tasks before starting two
    /// new tasks. Tasks for services that don't use a load balancer are considered healthy
    /// if they're in the <c>RUNNING</c> state. Tasks for services that use a load balancer
    /// are considered healthy if they're in the <c>RUNNING</c> state and are reported as
    /// healthy by the load balancer.
    /// </para></li><li><para>
    /// The <c>maximumPercent</c> parameter represents an upper limit on the number of running
    /// tasks during a deployment. You can use it to define the deployment batch size. For
    /// example, if <c>desiredCount</c> is four tasks, a maximum of 200% starts four new tasks
    /// before stopping the four older tasks (provided that the cluster resources required
    /// to do this are available).
    /// </para></li></ul><para>
    /// When <a>UpdateService</a> stops a task during a deployment, the equivalent of <c>docker
    /// stop</c> is issued to the containers running in the task. This results in a <c>SIGTERM</c>
    /// and a 30-second timeout. After this, <c>SIGKILL</c> is sent and the containers are
    /// forcibly stopped. If the container handles the <c>SIGTERM</c> gracefully and exits
    /// within 30 seconds from receiving it, no <c>SIGKILL</c> is sent.
    /// </para><para>
    /// When the service scheduler launches new tasks, it determines task placement in your
    /// cluster with the following logic.
    /// </para><ul><li><para>
    /// Determine which of the container instances in your cluster can support your service's
    /// task definition. For example, they have the required CPU, memory, ports, and container
    /// instance attributes.
    /// </para></li><li><para>
    /// By default, the service scheduler attempts to balance tasks across Availability Zones
    /// in this manner even though you can choose a different placement strategy.
    /// </para><ul><li><para>
    /// Sort the valid container instances by the fewest number of running tasks for this
    /// service in the same Availability Zone as the instance. For example, if zone A has
    /// one running service task and zones B and C each have zero, valid container instances
    /// in either zone B or C are considered optimal for placement.
    /// </para></li><li><para>
    /// Place the new service task on a valid container instance in an optimal Availability
    /// Zone (based on the previous steps), favoring container instances with the fewest number
    /// of running tasks for this service.
    /// </para></li></ul></li></ul><para>
    /// When the service scheduler stops running tasks, it attempts to maintain balance across
    /// the Availability Zones in your cluster using the following logic: 
    /// </para><ul><li><para>
    /// Sort the container instances by the largest number of running tasks for this service
    /// in the same Availability Zone as the instance. For example, if zone A has one running
    /// service task and zones B and C each have two, container instances in either zone B
    /// or C are considered optimal for termination.
    /// </para></li><li><para>
    /// Stop the task on a container instance in an optimal Availability Zone (based on the
    /// previous steps), favoring container instances with the largest number of running tasks
    /// for this service.
    /// </para></li></ul><note><para>
    /// You must have a service-linked role when you update any of the following service properties:
    /// </para><ul><li><para><c>loadBalancers</c>,
    /// </para></li><li><para><c>serviceRegistries</c></para></li></ul><para>
    /// For more information about the role see the <c>CreateService</c> request parameter
    /// <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_CreateService.html#ECS-CreateService-request-role"><c>role</c></a>. 
    /// </para></note>
    /// </summary>
    [Cmdlet("Update", "ECSService", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.ECS.Model.Service")]
    [AWSCmdlet("Calls the Amazon EC2 Container Service UpdateService API operation.", Operation = new[] {"UpdateService"}, SelectReturnType = typeof(Amazon.ECS.Model.UpdateServiceResponse))]
    [AWSCmdletOutput("Amazon.ECS.Model.Service or Amazon.ECS.Model.UpdateServiceResponse",
        "This cmdlet returns an Amazon.ECS.Model.Service object.",
        "The service call response (type Amazon.ECS.Model.UpdateServiceResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateECSServiceCmdlet : AmazonECSClientCmdlet, IExecutor
    {
        
        protected override bool IsGeneratedCmdlet { get; set; } = true;
        
        #region Parameter Alarms_AlarmName
        /// <summary>
        /// <para>
        /// <para>One or more CloudWatch alarm names. Use a "," to separate the alarms.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfiguration_Alarms_AlarmNames")]
        public System.String[] Alarms_AlarmName { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_AssignPublicIp
        /// <summary>
        /// <para>
        /// <para>Whether the task's elastic network interface receives a public IP address. The default
        /// value is <c>DISABLED</c>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_AwsvpcConfiguration_AssignPublicIp")]
        [AWSConstantClassSource("Amazon.ECS.AssignPublicIp")]
        public Amazon.ECS.AssignPublicIp AwsvpcConfiguration_AssignPublicIp { get; set; }
        #endregion
        
        #region Parameter CapacityProviderStrategy
        /// <summary>
        /// <para>
        /// <para>The capacity provider strategy to update the service to use.</para><para>if the service uses the default capacity provider strategy for the cluster, the service
        /// can be updated to use one or more capacity providers as opposed to the default capacity
        /// provider strategy. However, when a service is using a capacity provider strategy that's
        /// not the default capacity provider strategy, the service can't be updated to use the
        /// cluster's default capacity provider strategy.</para><para>A capacity provider strategy consists of one or more capacity providers along with
        /// the <c>base</c> and <c>weight</c> to assign to them. A capacity provider must be associated
        /// with the cluster to be used in a capacity provider strategy. The <a>PutClusterCapacityProviders</a>
        /// API is used to associate a capacity provider with a cluster. Only capacity providers
        /// with an <c>ACTIVE</c> or <c>UPDATING</c> status can be used.</para><para>If specifying a capacity provider that uses an Auto Scaling group, the capacity provider
        /// must already be created. New capacity providers can be created with the <a>CreateCapacityProvider</a>
        /// API operation.</para><para>To use a Fargate capacity provider, specify either the <c>FARGATE</c> or <c>FARGATE_SPOT</c>
        /// capacity providers. The Fargate capacity providers are available to all accounts and
        /// only need to be associated with a cluster to be used.</para><para>The <a>PutClusterCapacityProviders</a> API operation is used to update the list of
        /// available capacity providers for a cluster after the cluster is created.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ECS.Model.CapacityProviderStrategyItem[] CapacityProviderStrategy { get; set; }
        #endregion
        
        #region Parameter Cluster
        /// <summary>
        /// <para>
        /// <para>The short name or full Amazon Resource Name (ARN) of the cluster that your service
        /// runs on. If you do not specify a cluster, the default cluster is assumed.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        public System.String Cluster { get; set; }
        #endregion
        
        #region Parameter DesiredCount
        /// <summary>
        /// <para>
        /// <para>The number of instantiations of the task to place and keep running in your service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DesiredCount { get; set; }
        #endregion
        
        #region Parameter Alarms_Enable
        /// <summary>
        /// <para>
        /// <para>Determines whether to use the CloudWatch alarm option in the service deployment process.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfiguration_Alarms_Enable")]
        public System.Boolean? Alarms_Enable { get; set; }
        #endregion
        
        #region Parameter DeploymentCircuitBreaker_Enable
        /// <summary>
        /// <para>
        /// <para>Determines whether to use the deployment circuit breaker logic for the service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfiguration_DeploymentCircuitBreaker_Enable")]
        public System.Boolean? DeploymentCircuitBreaker_Enable { get; set; }
        #endregion
        
        #region Parameter ServiceConnectConfiguration_Enabled
        /// <summary>
        /// <para>
        /// <para>Specifies whether to use Service Connect with this service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ServiceConnectConfiguration_Enabled { get; set; }
        #endregion
        
        #region Parameter EnableECSManagedTag
        /// <summary>
        /// <para>
        /// <para>Determines whether to turn on Amazon ECS managed tags for the tasks in the service.
        /// For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/ecs-using-tags.html">Tagging
        /// Your Amazon ECS Resources</a> in the <i>Amazon Elastic Container Service Developer
        /// Guide</i>.</para><para>Only tasks launched after the update will reflect the update. To update the tags on
        /// all tasks, set <c>forceNewDeployment</c> to <c>true</c>, so that Amazon ECS starts
        /// new tasks with the updated tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("EnableECSManagedTags")]
        public System.Boolean? EnableECSManagedTag { get; set; }
        #endregion
        
        #region Parameter EnableExecuteCommand
        /// <summary>
        /// <para>
        /// <para>If <c>true</c>, this enables execute command functionality on all task containers.</para><para>If you do not want to override the value that was set when the service was created,
        /// you can set this to <c>null</c> when performing this action.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? EnableExecuteCommand { get; set; }
        #endregion
        
        #region Parameter ForceNewDeployment
        /// <summary>
        /// <para>
        /// <para>Determines whether to force a new deployment of the service. By default, deployments
        /// aren't forced. You can use this option to start a new deployment with no service definition
        /// changes. For example, you can update a service's tasks to use a newer Docker image
        /// with the same image/tag combination (<c>my_image:latest</c>) or to roll Fargate tasks
        /// onto a newer platform version.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Boolean? ForceNewDeployment { get; set; }
        #endregion
        
        #region Parameter HealthCheckGracePeriodSecond
        /// <summary>
        /// <para>
        /// <para>The period of time, in seconds, that the Amazon ECS service scheduler ignores unhealthy
        /// Elastic Load Balancing target health checks after a task has first started. This is
        /// only valid if your service is configured to use a load balancer. If your service's
        /// tasks take a while to start and respond to Elastic Load Balancing health checks, you
        /// can specify a health check grace period of up to 2,147,483,647 seconds. During that
        /// time, the Amazon ECS service scheduler ignores the Elastic Load Balancing health check
        /// status. This grace period can prevent the ECS service scheduler from marking tasks
        /// as unhealthy and stopping them before they have time to come up.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("HealthCheckGracePeriodSeconds")]
        public System.Int32? HealthCheckGracePeriodSecond { get; set; }
        #endregion
        
        #region Parameter LoadBalancer
        /// <summary>
        /// <para>
        /// <para>A list of Elastic Load Balancing load balancer objects. It contains the load balancer
        /// name, the container name, and the container port to access from the load balancer.
        /// The container name is as it appears in a container definition.</para><para>When you add, update, or remove a load balancer configuration, Amazon ECS starts new
        /// tasks with the updated Elastic Load Balancing configuration, and then stops the old
        /// tasks when the new tasks are running.</para><para>For services that use rolling updates, you can add, update, or remove Elastic Load
        /// Balancing target groups. You can update from a single target group to multiple target
        /// groups and from multiple target groups to a single target group.</para><para>For services that use blue/green deployments, you can update Elastic Load Balancing
        /// target groups by using <c><a href="https://docs.aws.amazon.com/codedeploy/latest/APIReference/API_CreateDeployment.html">CreateDeployment</a></c> through CodeDeploy. Note that multiple target groups are not supported for blue/green
        /// deployments. For more information see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/register-multiple-targetgroups.html">Register
        /// multiple target groups with a service</a> in the <i>Amazon Elastic Container Service
        /// Developer Guide</i>. </para><para>For services that use the external deployment controller, you can add, update, or
        /// remove load balancers by using <a href="https://docs.aws.amazon.com/AmazonECS/latest/APIReference/API_CreateTaskSet.html">CreateTaskSet</a>.
        /// Note that multiple target groups are not supported for external deployments. For more
        /// information see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/register-multiple-targetgroups.html">Register
        /// multiple target groups with a service</a> in the <i>Amazon Elastic Container Service
        /// Developer Guide</i>. </para><para>You can remove existing <c>loadBalancers</c> by passing an empty list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("LoadBalancers")]
        public Amazon.ECS.Model.LoadBalancer[] LoadBalancer { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_LogDriver
        /// <summary>
        /// <para>
        /// <para>The log driver to use for the container.</para><para>For tasks on Fargate, the supported log drivers are <c>awslogs</c>, <c>splunk</c>,
        /// and <c>awsfirelens</c>.</para><para>For tasks hosted on Amazon EC2 instances, the supported log drivers are <c>awslogs</c>,
        /// <c>fluentd</c>, <c>gelf</c>, <c>json-file</c>, <c>journald</c>, <c>logentries</c>,<c>syslog</c>,
        /// <c>splunk</c>, and <c>awsfirelens</c>.</para><para>For more information about using the <c>awslogs</c> log driver, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/using_awslogs.html">Using
        /// the awslogs log driver</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para><para>For more information about using the <c>awsfirelens</c> log driver, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/using_firelens.html">Custom
        /// log routing</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para><note><para>If you have a custom driver that isn't listed, you can fork the Amazon ECS container
        /// agent project that's <a href="https://github.com/aws/amazon-ecs-agent">available on
        /// GitHub</a> and customize it to work with that driver. We encourage you to submit pull
        /// requests for changes that you would like to have included. However, we don't currently
        /// provide support for running modified copies of this software.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceConnectConfiguration_LogConfiguration_LogDriver")]
        [AWSConstantClassSource("Amazon.ECS.LogDriver")]
        public Amazon.ECS.LogDriver LogConfiguration_LogDriver { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_MaximumPercent
        /// <summary>
        /// <para>
        /// <para>If a service is using the rolling update (<c>ECS</c>) deployment type, the <c>maximumPercent</c>
        /// parameter represents an upper limit on the number of your service's tasks that are
        /// allowed in the <c>RUNNING</c> or <c>PENDING</c> state during a deployment, as a percentage
        /// of the <c>desiredCount</c> (rounded down to the nearest integer). This parameter enables
        /// you to define the deployment batch size. For example, if your service is using the
        /// <c>REPLICA</c> service scheduler and has a <c>desiredCount</c> of four tasks and a
        /// <c>maximumPercent</c> value of 200%, the scheduler may start four new tasks before
        /// stopping the four older tasks (provided that the cluster resources required to do
        /// this are available). The default <c>maximumPercent</c> value for a service using the
        /// <c>REPLICA</c> service scheduler is 200%.</para><para>If a service is using either the blue/green (<c>CODE_DEPLOY</c>) or <c>EXTERNAL</c>
        /// deployment types and tasks that use the EC2 launch type, the <b>maximum percent</b>
        /// value is set to the default value and is used to define the upper limit on the number
        /// of the tasks in the service that remain in the <c>RUNNING</c> state while the container
        /// instances are in the <c>DRAINING</c> state. If the tasks in the service use the Fargate
        /// launch type, the maximum percent value is not used, although it is returned when describing
        /// your service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DeploymentConfiguration_MaximumPercent { get; set; }
        #endregion
        
        #region Parameter DeploymentConfiguration_MinimumHealthyPercent
        /// <summary>
        /// <para>
        /// <para>If a service is using the rolling update (<c>ECS</c>) deployment type, the <c>minimumHealthyPercent</c>
        /// represents a lower limit on the number of your service's tasks that must remain in
        /// the <c>RUNNING</c> state during a deployment, as a percentage of the <c>desiredCount</c>
        /// (rounded up to the nearest integer). This parameter enables you to deploy without
        /// using additional cluster capacity. For example, if your service has a <c>desiredCount</c>
        /// of four tasks and a <c>minimumHealthyPercent</c> of 50%, the service scheduler may
        /// stop two existing tasks to free up cluster capacity before starting two new tasks.
        /// </para><para>For services that <i>do not</i> use a load balancer, the following should be noted:</para><ul><li><para>A service is considered healthy if all essential containers within the tasks in the
        /// service pass their health checks.</para></li><li><para>If a task has no essential containers with a health check defined, the service scheduler
        /// will wait for 40 seconds after a task reaches a <c>RUNNING</c> state before the task
        /// is counted towards the minimum healthy percent total.</para></li><li><para>If a task has one or more essential containers with a health check defined, the service
        /// scheduler will wait for the task to reach a healthy status before counting it towards
        /// the minimum healthy percent total. A task is considered healthy when all essential
        /// containers within the task have passed their health checks. The amount of time the
        /// service scheduler can wait for is determined by the container health check settings.
        /// </para></li></ul><para>For services are that <i>do</i> use a load balancer, the following should be noted:</para><ul><li><para>If a task has no essential containers with a health check defined, the service scheduler
        /// will wait for the load balancer target group health check to return a healthy status
        /// before counting the task towards the minimum healthy percent total.</para></li><li><para>If a task has an essential container with a health check defined, the service scheduler
        /// will wait for both the task to reach a healthy status and the load balancer target
        /// group health check to return a healthy status before counting the task towards the
        /// minimum healthy percent total.</para></li></ul><para>If a service is using either the blue/green (<c>CODE_DEPLOY</c>) or <c>EXTERNAL</c>
        /// deployment types and is running tasks that use the EC2 launch type, the <b>minimum
        /// healthy percent</b> value is set to the default value and is used to define the lower
        /// limit on the number of the tasks in the service that remain in the <c>RUNNING</c>
        /// state while the container instances are in the <c>DRAINING</c> state. If a service
        /// is using either the blue/green (<c>CODE_DEPLOY</c>) or <c>EXTERNAL</c> deployment
        /// types and is running tasks that use the Fargate launch type, the minimum healthy percent
        /// value is not used, although it is returned when describing your service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? DeploymentConfiguration_MinimumHealthyPercent { get; set; }
        #endregion
        
        #region Parameter ServiceConnectConfiguration_Namespace
        /// <summary>
        /// <para>
        /// <para>The namespace name or full Amazon Resource Name (ARN) of the Cloud Map namespace for
        /// use with Service Connect. The namespace must be in the same Amazon Web Services Region
        /// as the Amazon ECS service and cluster. The type of namespace doesn't affect Service
        /// Connect. For more information about Cloud Map, see <a href="https://docs.aws.amazon.com/cloud-map/latest/dg/working-with-services.html">Working
        /// with Services</a> in the <i>Cloud Map Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String ServiceConnectConfiguration_Namespace { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_Option
        /// <summary>
        /// <para>
        /// <para>The configuration options to send to the log driver. This parameter requires version
        /// 1.19 of the Docker Remote API or greater on your container instance. To check the
        /// Docker Remote API version on your container instance, log in to your container instance
        /// and run the following command: <c>sudo docker version --format '{{.Server.APIVersion}}'</c></para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceConnectConfiguration_LogConfiguration_Options")]
        public System.Collections.Hashtable LogConfiguration_Option { get; set; }
        #endregion
        
        #region Parameter PlacementConstraint
        /// <summary>
        /// <para>
        /// <para>An array of task placement constraint objects to update the service to use. If no
        /// value is specified, the existing placement constraints for the service will remain
        /// unchanged. If this value is specified, it will override any existing placement constraints
        /// defined for the service. To remove all existing placement constraints, specify an
        /// empty array.</para><para>You can specify a maximum of 10 constraints for each task. This limit includes constraints
        /// in the task definition and those specified at runtime.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PlacementConstraints")]
        public Amazon.ECS.Model.PlacementConstraint[] PlacementConstraint { get; set; }
        #endregion
        
        #region Parameter PlacementStrategy
        /// <summary>
        /// <para>
        /// <para>The task placement strategy objects to update the service to use. If no value is specified,
        /// the existing placement strategy for the service will remain unchanged. If this value
        /// is specified, it will override the existing placement strategy defined for the service.
        /// To remove an existing placement strategy, specify an empty object.</para><para>You can specify a maximum of five strategy rules for each service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.ECS.Model.PlacementStrategy[] PlacementStrategy { get; set; }
        #endregion
        
        #region Parameter PlatformVersion
        /// <summary>
        /// <para>
        /// <para>The platform version that your tasks in the service run on. A platform version is
        /// only specified for tasks using the Fargate launch type. If a platform version is not
        /// specified, the <c>LATEST</c> platform version is used. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/platform_versions.html">Fargate
        /// Platform Versions</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String PlatformVersion { get; set; }
        #endregion
        
        #region Parameter PropagateTag
        /// <summary>
        /// <para>
        /// <para>Determines whether to propagate the tags from the task definition or the service to
        /// the task. If no value is specified, the tags aren't propagated.</para><para>Only tasks launched after the update will reflect the update. To update the tags on
        /// all tasks, set <c>forceNewDeployment</c> to <c>true</c>, so that Amazon ECS starts
        /// new tasks with the updated tags.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("PropagateTags")]
        [AWSConstantClassSource("Amazon.ECS.PropagateTags")]
        public Amazon.ECS.PropagateTags PropagateTag { get; set; }
        #endregion
        
        #region Parameter Alarms_Rollback
        /// <summary>
        /// <para>
        /// <para>Determines whether to configure Amazon ECS to roll back the service if a service deployment
        /// fails. If rollback is used, when a service deployment fails, the service is rolled
        /// back to the last deployment that completed successfully.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfiguration_Alarms_Rollback")]
        public System.Boolean? Alarms_Rollback { get; set; }
        #endregion
        
        #region Parameter DeploymentCircuitBreaker_Rollback
        /// <summary>
        /// <para>
        /// <para>Determines whether to configure Amazon ECS to roll back the service if a service deployment
        /// fails. If rollback is on, when a service deployment fails, the service is rolled back
        /// to the last deployment that completed successfully.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("DeploymentConfiguration_DeploymentCircuitBreaker_Rollback")]
        public System.Boolean? DeploymentCircuitBreaker_Rollback { get; set; }
        #endregion
        
        #region Parameter LogConfiguration_SecretOption
        /// <summary>
        /// <para>
        /// <para>The secrets to pass to the log configuration. For more information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/specifying-sensitive-data.html">Specifying
        /// sensitive data</a> in the <i>Amazon Elastic Container Service Developer Guide</i>.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceConnectConfiguration_LogConfiguration_SecretOptions")]
        public Amazon.ECS.Model.Secret[] LogConfiguration_SecretOption { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_SecurityGroup
        /// <summary>
        /// <para>
        /// <para>The IDs of the security groups associated with the task or service. If you don't specify
        /// a security group, the default security group for the VPC is used. There's a limit
        /// of 5 security groups that can be specified per <c>AwsVpcConfiguration</c>.</para><note><para>All specified security groups must be from the same VPC.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_AwsvpcConfiguration_SecurityGroups")]
        public System.String[] AwsvpcConfiguration_SecurityGroup { get; set; }
        #endregion
        
        #region Parameter Service
        /// <summary>
        /// <para>
        /// <para>The name of the service to update.</para>
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
        public System.String Service { get; set; }
        #endregion
        
        #region Parameter ServiceRegistry
        /// <summary>
        /// <para>
        /// <para>The details for the service discovery registries to assign to this service. For more
        /// information, see <a href="https://docs.aws.amazon.com/AmazonECS/latest/developerguide/service-discovery.html">Service
        /// Discovery</a>.</para><para>When you add, update, or remove the service registries configuration, Amazon ECS starts
        /// new tasks with the updated service registries configuration, and then stops the old
        /// tasks when the new tasks are running.</para><para>You can remove existing <c>serviceRegistries</c> by passing an empty list.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceRegistries")]
        public Amazon.ECS.Model.ServiceRegistry[] ServiceRegistry { get; set; }
        #endregion
        
        #region Parameter ServiceConnectConfiguration_Service
        /// <summary>
        /// <para>
        /// <para>The list of Service Connect service objects. These are names and aliases (also known
        /// as endpoints) that are used by other Amazon ECS services to connect to this service.
        /// </para><para>This field is not required for a "client" Amazon ECS service that's a member of a
        /// namespace only to connect to other services within the namespace. An example of this
        /// would be a frontend application that accepts incoming requests from either a load
        /// balancer that's attached to the service or by other means.</para><para>An object selects a port from the task definition, assigns a name for the Cloud Map
        /// service, and a list of aliases (endpoints) and ports for client applications to refer
        /// to this service.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("ServiceConnectConfiguration_Services")]
        public Amazon.ECS.Model.ServiceConnectService[] ServiceConnectConfiguration_Service { get; set; }
        #endregion
        
        #region Parameter AwsvpcConfiguration_Subnet
        /// <summary>
        /// <para>
        /// <para>The IDs of the subnets associated with the task or service. There's a limit of 16
        /// subnets that can be specified per <c>AwsVpcConfiguration</c>.</para><note><para>All specified subnets must be from the same VPC.</para></note>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [Alias("NetworkConfiguration_AwsvpcConfiguration_Subnets")]
        public System.String[] AwsvpcConfiguration_Subnet { get; set; }
        #endregion
        
        #region Parameter TaskDefinition
        /// <summary>
        /// <para>
        /// <para>The <c>family</c> and <c>revision</c> (<c>family:revision</c>) or full ARN of the
        /// task definition to run in your service. If a <c>revision</c> is not specified, the
        /// latest <c>ACTIVE</c> revision is used. If you modify the task definition with <c>UpdateService</c>,
        /// Amazon ECS spawns a task with the new version of the task definition and then stops
        /// an old task after the new version is running.</para>
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String TaskDefinition { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Service'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.ECS.Model.UpdateServiceResponse).
        /// Specifying the name of a property of type Amazon.ECS.Model.UpdateServiceResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Service";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the Cluster parameter.
        /// The -PassThru parameter is deprecated, use -Select '^Cluster' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^Cluster' instead. This parameter will be removed in a future version.")]
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
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.Service), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-ECSService (UpdateService)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.ECS.Model.UpdateServiceResponse, UpdateECSServiceCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.Cluster;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.CapacityProviderStrategy != null)
            {
                context.CapacityProviderStrategy = new List<Amazon.ECS.Model.CapacityProviderStrategyItem>(this.CapacityProviderStrategy);
            }
            context.Cluster = this.Cluster;
            if (this.Alarms_AlarmName != null)
            {
                context.Alarms_AlarmName = new List<System.String>(this.Alarms_AlarmName);
            }
            context.Alarms_Enable = this.Alarms_Enable;
            context.Alarms_Rollback = this.Alarms_Rollback;
            context.DeploymentCircuitBreaker_Enable = this.DeploymentCircuitBreaker_Enable;
            context.DeploymentCircuitBreaker_Rollback = this.DeploymentCircuitBreaker_Rollback;
            context.DeploymentConfiguration_MaximumPercent = this.DeploymentConfiguration_MaximumPercent;
            context.DeploymentConfiguration_MinimumHealthyPercent = this.DeploymentConfiguration_MinimumHealthyPercent;
            context.DesiredCount = this.DesiredCount;
            context.EnableECSManagedTag = this.EnableECSManagedTag;
            context.EnableExecuteCommand = this.EnableExecuteCommand;
            context.ForceNewDeployment = this.ForceNewDeployment;
            context.HealthCheckGracePeriodSecond = this.HealthCheckGracePeriodSecond;
            if (this.LoadBalancer != null)
            {
                context.LoadBalancer = new List<Amazon.ECS.Model.LoadBalancer>(this.LoadBalancer);
            }
            context.AwsvpcConfiguration_AssignPublicIp = this.AwsvpcConfiguration_AssignPublicIp;
            if (this.AwsvpcConfiguration_SecurityGroup != null)
            {
                context.AwsvpcConfiguration_SecurityGroup = new List<System.String>(this.AwsvpcConfiguration_SecurityGroup);
            }
            if (this.AwsvpcConfiguration_Subnet != null)
            {
                context.AwsvpcConfiguration_Subnet = new List<System.String>(this.AwsvpcConfiguration_Subnet);
            }
            if (this.PlacementConstraint != null)
            {
                context.PlacementConstraint = new List<Amazon.ECS.Model.PlacementConstraint>(this.PlacementConstraint);
            }
            if (this.PlacementStrategy != null)
            {
                context.PlacementStrategy = new List<Amazon.ECS.Model.PlacementStrategy>(this.PlacementStrategy);
            }
            context.PlatformVersion = this.PlatformVersion;
            context.PropagateTag = this.PropagateTag;
            context.Service = this.Service;
            #if MODULAR
            if (this.Service == null && ParameterWasBound(nameof(this.Service)))
            {
                WriteWarning("You are passing $null as a value for parameter Service which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.ServiceConnectConfiguration_Enabled = this.ServiceConnectConfiguration_Enabled;
            context.LogConfiguration_LogDriver = this.LogConfiguration_LogDriver;
            if (this.LogConfiguration_Option != null)
            {
                context.LogConfiguration_Option = new Dictionary<System.String, System.String>(StringComparer.Ordinal);
                foreach (var hashKey in this.LogConfiguration_Option.Keys)
                {
                    context.LogConfiguration_Option.Add((String)hashKey, (String)(this.LogConfiguration_Option[hashKey]));
                }
            }
            if (this.LogConfiguration_SecretOption != null)
            {
                context.LogConfiguration_SecretOption = new List<Amazon.ECS.Model.Secret>(this.LogConfiguration_SecretOption);
            }
            context.ServiceConnectConfiguration_Namespace = this.ServiceConnectConfiguration_Namespace;
            if (this.ServiceConnectConfiguration_Service != null)
            {
                context.ServiceConnectConfiguration_Service = new List<Amazon.ECS.Model.ServiceConnectService>(this.ServiceConnectConfiguration_Service);
            }
            if (this.ServiceRegistry != null)
            {
                context.ServiceRegistry = new List<Amazon.ECS.Model.ServiceRegistry>(this.ServiceRegistry);
            }
            context.TaskDefinition = this.TaskDefinition;
            
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
            var request = new Amazon.ECS.Model.UpdateServiceRequest();
            
            if (cmdletContext.CapacityProviderStrategy != null)
            {
                request.CapacityProviderStrategy = cmdletContext.CapacityProviderStrategy;
            }
            if (cmdletContext.Cluster != null)
            {
                request.Cluster = cmdletContext.Cluster;
            }
            
             // populate DeploymentConfiguration
            var requestDeploymentConfigurationIsNull = true;
            request.DeploymentConfiguration = new Amazon.ECS.Model.DeploymentConfiguration();
            System.Int32? requestDeploymentConfiguration_deploymentConfiguration_MaximumPercent = null;
            if (cmdletContext.DeploymentConfiguration_MaximumPercent != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_MaximumPercent = cmdletContext.DeploymentConfiguration_MaximumPercent.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_MaximumPercent != null)
            {
                request.DeploymentConfiguration.MaximumPercent = requestDeploymentConfiguration_deploymentConfiguration_MaximumPercent.Value;
                requestDeploymentConfigurationIsNull = false;
            }
            System.Int32? requestDeploymentConfiguration_deploymentConfiguration_MinimumHealthyPercent = null;
            if (cmdletContext.DeploymentConfiguration_MinimumHealthyPercent != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_MinimumHealthyPercent = cmdletContext.DeploymentConfiguration_MinimumHealthyPercent.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_MinimumHealthyPercent != null)
            {
                request.DeploymentConfiguration.MinimumHealthyPercent = requestDeploymentConfiguration_deploymentConfiguration_MinimumHealthyPercent.Value;
                requestDeploymentConfigurationIsNull = false;
            }
            Amazon.ECS.Model.DeploymentCircuitBreaker requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker = null;
            
             // populate DeploymentCircuitBreaker
            var requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreakerIsNull = true;
            requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker = new Amazon.ECS.Model.DeploymentCircuitBreaker();
            System.Boolean? requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker_deploymentCircuitBreaker_Enable = null;
            if (cmdletContext.DeploymentCircuitBreaker_Enable != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker_deploymentCircuitBreaker_Enable = cmdletContext.DeploymentCircuitBreaker_Enable.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker_deploymentCircuitBreaker_Enable != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker.Enable = requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker_deploymentCircuitBreaker_Enable.Value;
                requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreakerIsNull = false;
            }
            System.Boolean? requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker_deploymentCircuitBreaker_Rollback = null;
            if (cmdletContext.DeploymentCircuitBreaker_Rollback != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker_deploymentCircuitBreaker_Rollback = cmdletContext.DeploymentCircuitBreaker_Rollback.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker_deploymentCircuitBreaker_Rollback != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker.Rollback = requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker_deploymentCircuitBreaker_Rollback.Value;
                requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreakerIsNull = false;
            }
             // determine if requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker should be set to null
            if (requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreakerIsNull)
            {
                requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker = null;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker != null)
            {
                request.DeploymentConfiguration.DeploymentCircuitBreaker = requestDeploymentConfiguration_deploymentConfiguration_DeploymentCircuitBreaker;
                requestDeploymentConfigurationIsNull = false;
            }
            Amazon.ECS.Model.DeploymentAlarms requestDeploymentConfiguration_deploymentConfiguration_Alarms = null;
            
             // populate Alarms
            var requestDeploymentConfiguration_deploymentConfiguration_AlarmsIsNull = true;
            requestDeploymentConfiguration_deploymentConfiguration_Alarms = new Amazon.ECS.Model.DeploymentAlarms();
            List<System.String> requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_AlarmName = null;
            if (cmdletContext.Alarms_AlarmName != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_AlarmName = cmdletContext.Alarms_AlarmName;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_AlarmName != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms.AlarmNames = requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_AlarmName;
                requestDeploymentConfiguration_deploymentConfiguration_AlarmsIsNull = false;
            }
            System.Boolean? requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_Enable = null;
            if (cmdletContext.Alarms_Enable != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_Enable = cmdletContext.Alarms_Enable.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_Enable != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms.Enable = requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_Enable.Value;
                requestDeploymentConfiguration_deploymentConfiguration_AlarmsIsNull = false;
            }
            System.Boolean? requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_Rollback = null;
            if (cmdletContext.Alarms_Rollback != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_Rollback = cmdletContext.Alarms_Rollback.Value;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_Rollback != null)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms.Rollback = requestDeploymentConfiguration_deploymentConfiguration_Alarms_alarms_Rollback.Value;
                requestDeploymentConfiguration_deploymentConfiguration_AlarmsIsNull = false;
            }
             // determine if requestDeploymentConfiguration_deploymentConfiguration_Alarms should be set to null
            if (requestDeploymentConfiguration_deploymentConfiguration_AlarmsIsNull)
            {
                requestDeploymentConfiguration_deploymentConfiguration_Alarms = null;
            }
            if (requestDeploymentConfiguration_deploymentConfiguration_Alarms != null)
            {
                request.DeploymentConfiguration.Alarms = requestDeploymentConfiguration_deploymentConfiguration_Alarms;
                requestDeploymentConfigurationIsNull = false;
            }
             // determine if request.DeploymentConfiguration should be set to null
            if (requestDeploymentConfigurationIsNull)
            {
                request.DeploymentConfiguration = null;
            }
            if (cmdletContext.DesiredCount != null)
            {
                request.DesiredCount = cmdletContext.DesiredCount.Value;
            }
            if (cmdletContext.EnableECSManagedTag != null)
            {
                request.EnableECSManagedTags = cmdletContext.EnableECSManagedTag.Value;
            }
            if (cmdletContext.EnableExecuteCommand != null)
            {
                request.EnableExecuteCommand = cmdletContext.EnableExecuteCommand.Value;
            }
            if (cmdletContext.ForceNewDeployment != null)
            {
                request.ForceNewDeployment = cmdletContext.ForceNewDeployment.Value;
            }
            if (cmdletContext.HealthCheckGracePeriodSecond != null)
            {
                request.HealthCheckGracePeriodSeconds = cmdletContext.HealthCheckGracePeriodSecond.Value;
            }
            if (cmdletContext.LoadBalancer != null)
            {
                request.LoadBalancers = cmdletContext.LoadBalancer;
            }
            
             // populate NetworkConfiguration
            var requestNetworkConfigurationIsNull = true;
            request.NetworkConfiguration = new Amazon.ECS.Model.NetworkConfiguration();
            Amazon.ECS.Model.AwsVpcConfiguration requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration = null;
            
             // populate AwsvpcConfiguration
            var requestNetworkConfiguration_networkConfiguration_AwsvpcConfigurationIsNull = true;
            requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration = new Amazon.ECS.Model.AwsVpcConfiguration();
            Amazon.ECS.AssignPublicIp requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp = null;
            if (cmdletContext.AwsvpcConfiguration_AssignPublicIp != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp = cmdletContext.AwsvpcConfiguration_AssignPublicIp;
            }
            if (requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration.AssignPublicIp = requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_AssignPublicIp;
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfigurationIsNull = false;
            }
            List<System.String> requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup = null;
            if (cmdletContext.AwsvpcConfiguration_SecurityGroup != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup = cmdletContext.AwsvpcConfiguration_SecurityGroup;
            }
            if (requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration.SecurityGroups = requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_SecurityGroup;
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfigurationIsNull = false;
            }
            List<System.String> requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet = null;
            if (cmdletContext.AwsvpcConfiguration_Subnet != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet = cmdletContext.AwsvpcConfiguration_Subnet;
            }
            if (requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet != null)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration.Subnets = requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration_awsvpcConfiguration_Subnet;
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfigurationIsNull = false;
            }
             // determine if requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration should be set to null
            if (requestNetworkConfiguration_networkConfiguration_AwsvpcConfigurationIsNull)
            {
                requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration = null;
            }
            if (requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration != null)
            {
                request.NetworkConfiguration.AwsvpcConfiguration = requestNetworkConfiguration_networkConfiguration_AwsvpcConfiguration;
                requestNetworkConfigurationIsNull = false;
            }
             // determine if request.NetworkConfiguration should be set to null
            if (requestNetworkConfigurationIsNull)
            {
                request.NetworkConfiguration = null;
            }
            if (cmdletContext.PlacementConstraint != null)
            {
                request.PlacementConstraints = cmdletContext.PlacementConstraint;
            }
            if (cmdletContext.PlacementStrategy != null)
            {
                request.PlacementStrategy = cmdletContext.PlacementStrategy;
            }
            if (cmdletContext.PlatformVersion != null)
            {
                request.PlatformVersion = cmdletContext.PlatformVersion;
            }
            if (cmdletContext.PropagateTag != null)
            {
                request.PropagateTags = cmdletContext.PropagateTag;
            }
            if (cmdletContext.Service != null)
            {
                request.Service = cmdletContext.Service;
            }
            
             // populate ServiceConnectConfiguration
            var requestServiceConnectConfigurationIsNull = true;
            request.ServiceConnectConfiguration = new Amazon.ECS.Model.ServiceConnectConfiguration();
            System.Boolean? requestServiceConnectConfiguration_serviceConnectConfiguration_Enabled = null;
            if (cmdletContext.ServiceConnectConfiguration_Enabled != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_Enabled = cmdletContext.ServiceConnectConfiguration_Enabled.Value;
            }
            if (requestServiceConnectConfiguration_serviceConnectConfiguration_Enabled != null)
            {
                request.ServiceConnectConfiguration.Enabled = requestServiceConnectConfiguration_serviceConnectConfiguration_Enabled.Value;
                requestServiceConnectConfigurationIsNull = false;
            }
            System.String requestServiceConnectConfiguration_serviceConnectConfiguration_Namespace = null;
            if (cmdletContext.ServiceConnectConfiguration_Namespace != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_Namespace = cmdletContext.ServiceConnectConfiguration_Namespace;
            }
            if (requestServiceConnectConfiguration_serviceConnectConfiguration_Namespace != null)
            {
                request.ServiceConnectConfiguration.Namespace = requestServiceConnectConfiguration_serviceConnectConfiguration_Namespace;
                requestServiceConnectConfigurationIsNull = false;
            }
            List<Amazon.ECS.Model.ServiceConnectService> requestServiceConnectConfiguration_serviceConnectConfiguration_Service = null;
            if (cmdletContext.ServiceConnectConfiguration_Service != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_Service = cmdletContext.ServiceConnectConfiguration_Service;
            }
            if (requestServiceConnectConfiguration_serviceConnectConfiguration_Service != null)
            {
                request.ServiceConnectConfiguration.Services = requestServiceConnectConfiguration_serviceConnectConfiguration_Service;
                requestServiceConnectConfigurationIsNull = false;
            }
            Amazon.ECS.Model.LogConfiguration requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration = null;
            
             // populate LogConfiguration
            var requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfigurationIsNull = true;
            requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration = new Amazon.ECS.Model.LogConfiguration();
            Amazon.ECS.LogDriver requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_LogDriver = null;
            if (cmdletContext.LogConfiguration_LogDriver != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_LogDriver = cmdletContext.LogConfiguration_LogDriver;
            }
            if (requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_LogDriver != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration.LogDriver = requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_LogDriver;
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfigurationIsNull = false;
            }
            Dictionary<System.String, System.String> requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_Option = null;
            if (cmdletContext.LogConfiguration_Option != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_Option = cmdletContext.LogConfiguration_Option;
            }
            if (requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_Option != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration.Options = requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_Option;
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfigurationIsNull = false;
            }
            List<Amazon.ECS.Model.Secret> requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_SecretOption = null;
            if (cmdletContext.LogConfiguration_SecretOption != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_SecretOption = cmdletContext.LogConfiguration_SecretOption;
            }
            if (requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_SecretOption != null)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration.SecretOptions = requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration_logConfiguration_SecretOption;
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfigurationIsNull = false;
            }
             // determine if requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration should be set to null
            if (requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfigurationIsNull)
            {
                requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration = null;
            }
            if (requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration != null)
            {
                request.ServiceConnectConfiguration.LogConfiguration = requestServiceConnectConfiguration_serviceConnectConfiguration_LogConfiguration;
                requestServiceConnectConfigurationIsNull = false;
            }
             // determine if request.ServiceConnectConfiguration should be set to null
            if (requestServiceConnectConfigurationIsNull)
            {
                request.ServiceConnectConfiguration = null;
            }
            if (cmdletContext.ServiceRegistry != null)
            {
                request.ServiceRegistries = cmdletContext.ServiceRegistry;
            }
            if (cmdletContext.TaskDefinition != null)
            {
                request.TaskDefinition = cmdletContext.TaskDefinition;
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
        
        private Amazon.ECS.Model.UpdateServiceResponse CallAWSServiceOperation(IAmazonECS client, Amazon.ECS.Model.UpdateServiceRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon EC2 Container Service", "UpdateService");
            try
            {
                #if DESKTOP
                return client.UpdateService(request);
                #elif CORECLR
                return client.UpdateServiceAsync(request).GetAwaiter().GetResult();
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
            public List<Amazon.ECS.Model.CapacityProviderStrategyItem> CapacityProviderStrategy { get; set; }
            public System.String Cluster { get; set; }
            public List<System.String> Alarms_AlarmName { get; set; }
            public System.Boolean? Alarms_Enable { get; set; }
            public System.Boolean? Alarms_Rollback { get; set; }
            public System.Boolean? DeploymentCircuitBreaker_Enable { get; set; }
            public System.Boolean? DeploymentCircuitBreaker_Rollback { get; set; }
            public System.Int32? DeploymentConfiguration_MaximumPercent { get; set; }
            public System.Int32? DeploymentConfiguration_MinimumHealthyPercent { get; set; }
            public System.Int32? DesiredCount { get; set; }
            public System.Boolean? EnableECSManagedTag { get; set; }
            public System.Boolean? EnableExecuteCommand { get; set; }
            public System.Boolean? ForceNewDeployment { get; set; }
            public System.Int32? HealthCheckGracePeriodSecond { get; set; }
            public List<Amazon.ECS.Model.LoadBalancer> LoadBalancer { get; set; }
            public Amazon.ECS.AssignPublicIp AwsvpcConfiguration_AssignPublicIp { get; set; }
            public List<System.String> AwsvpcConfiguration_SecurityGroup { get; set; }
            public List<System.String> AwsvpcConfiguration_Subnet { get; set; }
            public List<Amazon.ECS.Model.PlacementConstraint> PlacementConstraint { get; set; }
            public List<Amazon.ECS.Model.PlacementStrategy> PlacementStrategy { get; set; }
            public System.String PlatformVersion { get; set; }
            public Amazon.ECS.PropagateTags PropagateTag { get; set; }
            public System.String Service { get; set; }
            public System.Boolean? ServiceConnectConfiguration_Enabled { get; set; }
            public Amazon.ECS.LogDriver LogConfiguration_LogDriver { get; set; }
            public Dictionary<System.String, System.String> LogConfiguration_Option { get; set; }
            public List<Amazon.ECS.Model.Secret> LogConfiguration_SecretOption { get; set; }
            public System.String ServiceConnectConfiguration_Namespace { get; set; }
            public List<Amazon.ECS.Model.ServiceConnectService> ServiceConnectConfiguration_Service { get; set; }
            public List<Amazon.ECS.Model.ServiceRegistry> ServiceRegistry { get; set; }
            public System.String TaskDefinition { get; set; }
            public System.Func<Amazon.ECS.Model.UpdateServiceResponse, UpdateECSServiceCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Service;
        }
        
    }
}
