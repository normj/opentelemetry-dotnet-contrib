// <copyright file="ActivityInstrumentationHelper.cs" company="OpenTelemetry Authors">
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

#nullable disable

#pragma warning disable IDE0005 // Using directive is unnecessary.
using System;
using System.Diagnostics;
using System.Linq.Expressions;
#pragma warning restore IDE0005 // Using directive is unnecessary.

namespace OpenTelemetry.Instrumentation;

internal static class ActivityInstrumentationHelper
{
    internal static readonly Action<Activity, ActivityKind> SetKindProperty = CreateActivityKindSetter();
    internal static readonly Action<Activity, ActivitySource> SetActivitySourceProperty = CreateActivitySourceSetter();

    private static Action<Activity, ActivitySource> CreateActivitySourceSetter()
    {
        ParameterExpression instance = Expression.Parameter(typeof(Activity), "instance");
        ParameterExpression propertyValue = Expression.Parameter(typeof(ActivitySource), "propertyValue");
        var body = Expression.Assign(Expression.Property(instance, "Source"), propertyValue);
        return Expression.Lambda<Action<Activity, ActivitySource>>(body, instance, propertyValue).Compile();
    }

    private static Action<Activity, ActivityKind> CreateActivityKindSetter()
    {
        ParameterExpression instance = Expression.Parameter(typeof(Activity), "instance");
        ParameterExpression propertyValue = Expression.Parameter(typeof(ActivityKind), "propertyValue");
        var body = Expression.Assign(Expression.Property(instance, "Kind"), propertyValue);
        return Expression.Lambda<Action<Activity, ActivityKind>>(body, instance, propertyValue).Compile();
    }
}
