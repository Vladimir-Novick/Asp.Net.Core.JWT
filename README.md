# Asp.Net.Core.JWT
JSON Web Token : An Example in  ASP.NET.CORE MVC

A JSON Web Token (JWT) is used to send information that can be verified and trusted by means of a digital signature. It comprises a compact and URL-safe JSON object, which is cryptographically signed to verify its authenticity, and which can also be encrypted if the payload contains sensitive information.

### Verifying a JSON Web Token (c#)

Using NUGET package: System.IdentityModel.Tokens.Jwt

      var jwtToken = new JwtSecurityToken(token);
       DateTime validDateTime = jwtToken.ValidTo;	
       
### Get custom Claim information (c#)       
	   var jwtToken = new JwtSecurityToken(token);
	   var str_dateOfBird = jwtToken.Claims.Where(c => c.Type == ClaimTypes.DateOfBirth)
                 .Select(c => c.Value).SingleOrDefault();

### Get Paiload info by name (c#)
	   var jwtToken = new JwtSecurityToken(token);
	   var value =  jwtToken.Payload["userInfo"];

### Get all custom information ( Pailoads ) (c#)

         var jwtToken = new JwtSecurityToken(token);
         List<PayloadItem> items = new List<PayloadItem>();
         foreach (var paiload in jwtToken.Payload)
         {
            PayloadItem item = new PayloadItem()
            {
               Key = paiload.Key,
               Value = paiload.Value.ToString()
            };
            items.Add(item);
         }
 
 ### Put custom information to Pailoads ( C# )
 
           var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretKey"));
            var signInCred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
                  users:{ "id": UserID},
                  issuer: "mysite.com",
                  audience: "yoursite.com",
                  expires: DateTime.Now.AddMinutes(30),
                  claims: claimsdata,                      
                signingCredentials: signInCred
                );
               //custom claims as per  requirements
                 jwtToken.Payload["userInfo"] = "My user info";
               //End of custom claims
              var jwt = new JwtSecurityTokenHandler().WriteToken(token);
	 
		 

Copyright (C) 2019 by Vladimir Novick http://www.linkedin.com/in/vladimirnovick , 

vlad.novick@gmail.com , https://github.com/Vladimir-Novick
		 
# License
		 
		 Copyright (C) 2019 by Vladimir Novick http://www.linkedin.com/in/vladimirnovick

		Permission is hereby granted, free of charge, to any person obtaining a copy
		of this software and associated documentation files (the "Software"), to deal
		in the Software without restriction, including without limitation the rights
		to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
		copies of the Software, and to permit persons to whom the Software is
		furnished to do so, subject to the following conditions:

		The above copyright notice and this permission notice shall be included in
		all copies or substantial portions of the Software.

		THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
		IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
		FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
		AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
		LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
		OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
		THE SOFTWARE. 
