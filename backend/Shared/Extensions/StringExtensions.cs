using System.Diagnostics.CodeAnalysis;

namespace Shared.Extensions;

public static class StringExtensions
{
	public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? value)
	{
		return string.IsNullOrWhiteSpace(value);
	}
}