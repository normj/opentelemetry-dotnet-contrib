// <copyright file="ListenerHandler.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

#nullable enable

using System.Diagnostics;

namespace OpenTelemetry.Instrumentation;

/// <summary>
/// ListenerHandler base class.
/// </summary>
internal abstract class ListenerHandler
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ListenerHandler"/> class.
    /// </summary>
    /// <param name="sourceName">The name of the <see cref="ListenerHandler"/>.</param>
    protected ListenerHandler(string sourceName)
    {
        this.SourceName = sourceName;
    }

    /// <summary>
    /// Gets the name of the <see cref="ListenerHandler"/>.
    /// </summary>
    public string SourceName { get; }

    /// <summary>
    /// Gets a value indicating whether the <see cref="ListenerHandler"/> supports NULL <see cref="Activity"/>.
    /// </summary>
    public virtual bool SupportsNullActivity { get; }

    /// <summary>
    /// Method called for an event with the suffix 'Start'.
    /// </summary>
    /// <param name="activity">The <see cref="Activity"/> to be started.</param>
    /// <param name="payload">An object that represent the value being passed as a payload for the event.</param>
    public virtual void OnStartActivity(Activity? activity, object? payload)
    {
    }

    /// <summary>
    /// Method called for an event with the suffix 'Stop'.
    /// </summary>
    /// <param name="activity">The <see cref="Activity"/> to be stopped.</param>
    /// <param name="payload">An object that represent the value being passed as a payload for the event.</param>
    public virtual void OnStopActivity(Activity? activity, object? payload)
    {
    }

    /// <summary>
    /// Method called for an event with the suffix 'Exception'.
    /// </summary>
    /// <param name="activity">The <see cref="Activity"/>.</param>
    /// <param name="payload">An object that represent the value being passed as a payload for the event.</param>
    public virtual void OnException(Activity? activity, object? payload)
    {
    }

    /// <summary>
    /// Method called for an event which does not have 'Start', 'Stop' or 'Exception' as suffix.
    /// </summary>
    /// <param name="name">Custom name.</param>
    /// <param name="activity">The <see cref="Activity"/> to be processed.</param>
    /// <param name="payload">An object that represent the value being passed as a payload for the event.</param>
    public virtual void OnCustom(string name, Activity? activity, object? payload)
    {
    }
}
