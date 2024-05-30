using CarBook.Application.Dtos;
using CarBook.Application.Features.Mediator.Results.AppUserResults;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Tools
{
	public class JwtTokenGenerator
	{
		public static TokenResponseDto GenerateToken(GetCheckAppUserQueryResult result)
		{
			var claims = new List<Claim>();

			// Check if the role is not null or empty and add to claims
			if (!string.IsNullOrWhiteSpace(result.Role))
				claims.Add(new Claim(ClaimTypes.Role, result.Role));

			// Add the NameIdentifier claim
			claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Id.ToString()));

			// Check if the username is not null or empty and add to claims
			if (!string.IsNullOrWhiteSpace(result.Username))
				claims.Add(new Claim("Username", result.Username));

			// Create the security key from the key specified in JwtTokenDefaults
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
			// Create signing credentials using the key and the HmacSha256 algorithm
			var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			// Set the token's expiration date
			var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

			// Create the JWT token
			JwtSecurityToken token = new JwtSecurityToken(
				issuer: JwtTokenDefaults.ValidIssuer,
				audience: JwtTokenDefaults.ValidAudience,
				claims: claims,  // Use the correct variable name
				notBefore: DateTime.UtcNow,
				expires: expireDate,
				signingCredentials: signingCredentials  // Ensure correct parameter name
			);

			// Create a JWT security token handler
			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			// Return the token and its expiration date encapsulated in a TokenResponseDto
			return new TokenResponseDto(tokenHandler.WriteToken(token), expireDate);
		}

	}
}
