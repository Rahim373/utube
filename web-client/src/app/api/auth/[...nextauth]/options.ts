import type { NextAuthOptions } from "next-auth"
import IdentityServer4 from "next-auth/providers/identity-server4"

const options: NextAuthOptions = {
    providers: [
        IdentityServer4({
            id: "webclient",
            name: "Identity Server",
            authorization: { params: { scope: "openid profile video-service.full-access" } },
            issuer: "http://localhost:53901",
            clientId: "webclient",
            clientSecret: "d7f02357090218c43f6e381745189aeb4ff9ca8e0e65499f3b740e2c51ef2aff",
        }),
    ],
    callbacks: {
        jwt: async ({ token, account }) => {
            if (account?.access_token) {
                token.access_token = account?.access_token;
            }
            return token;
        },
        session: async ({ session, token }) => {
            if (token) {
                session.access_token = token.access_token;
            }
            session.access_token = token.access_token;
            return Promise.resolve(session);
        },
    }
}

export default options;
