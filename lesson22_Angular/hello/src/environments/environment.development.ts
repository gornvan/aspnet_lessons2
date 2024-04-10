import { EnvironmentConfig } from "./environmentConfig";

const config = {
    API_URL: 'https://localhost:7255'
}

export const environment = new EnvironmentConfig(
    config.API_URL,
);
