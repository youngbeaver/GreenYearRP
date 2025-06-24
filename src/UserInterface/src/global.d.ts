/* eslint-disable @typescript-eslint/no-explicit-any */
declare const mp: {
    trigger(event: string, ...args: unknown[]): void;
    gui: {
        chat: {
            push(message: string): void;
        };
    };
    events: {
        add(eventName: string, handler: (...args: unknown[]) => void): void;
    };
    callServer(event: string, ...args: unknown[]): void;
};
