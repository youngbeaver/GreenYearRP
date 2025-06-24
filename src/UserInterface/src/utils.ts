// eslint-disable-next-line @typescript-eslint/no-explicit-any
export const callServer = (event: string, ...args: unknown[]): void => mp.trigger('utils:SendEventToServer', event, ...args);