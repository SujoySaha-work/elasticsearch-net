﻿using System;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Nest
{
	public partial interface IElasticClient
	{
		/// <summary>
		/// Retrieve information about the tasks currently executing on one or more nodes in the cluster.
		/// </summary>
		/// <param name="selector">A descriptor to further describe the tasks to retrieve information for</param>
		ITasksListResponse TasksList(Func<TasksListDescriptor, ITasksListRequest> selector = null);

		/// <inheritdoc/>
		ITasksListResponse TasksList(ITasksListRequest request);

		/// <inheritdoc/>
		Task<ITasksListResponse> TasksListAsync(Func<TasksListDescriptor, ITasksListRequest> selector = null);

		/// <inheritdoc/>
		Task<ITasksListResponse> TasksListAsync(ITasksListRequest request);
	}

	public partial class ElasticClient
	{
		/// <inheritdoc/>
		public ITasksListResponse TasksList(Func<TasksListDescriptor, ITasksListRequest> selector = null) =>
			this.TasksList(selector.InvokeOrDefault(new TasksListDescriptor()));

		/// <inheritdoc/>
		public ITasksListResponse TasksList(ITasksListRequest request) =>
			this.Dispatcher.Dispatch<ITasksListRequest, TasksListRequestParameters, TasksListResponse>(
				request,
				(p, d) => this.LowLevelDispatch.TasksListDispatch<TasksListResponse>(p)
			);

		/// <inheritdoc/>
		public Task<ITasksListResponse> TasksListAsync(Func<TasksListDescriptor, ITasksListRequest> selector = null) =>
			this.TasksListAsync(selector.InvokeOrDefault(new TasksListDescriptor()));

		/// <inheritdoc/>
		public Task<ITasksListResponse> TasksListAsync(ITasksListRequest request) =>
			this.Dispatcher.DispatchAsync<ITasksListRequest, TasksListRequestParameters, TasksListResponse, ITasksListResponse>(
				request,
				(p, d) => this.LowLevelDispatch.TasksListDispatchAsync<TasksListResponse>(p)
			);
	}
}
