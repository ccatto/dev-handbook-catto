> 1
**Question**: Which of the following is not an Angular directive from `@angular/common`?

- **ngClass** ✅ - Angular directive from `@angular/common` for adding/removing CSS classes dynamically.
- **ngFor** ✅ - Angular directive from `@angular/common` for rendering lists.
- **ngSwitch** ✅ - Angular directive from `@angular/common` for conditional rendering.
- **ngBind** ❌ - Not an Angular directive; commonly associated with AngularJS, not `@angular/common`.

**Summary**: `ngBind` is not an Angular directive from `@angular/common`, unlike `ngClass`, `ngFor`, and `ngSwitch`.

> 2
**Question**: Which of these options is the correct syntax for pipe parameters?

- **None of the above - all are incorrect** ❌ - Incorrect, as there is a correct syntax among the options.
- **{{ amount | currency : 'USD' }}** ✅ - Correct syntax for the Angular currency pipe, using a colon to specify the 'USD' parameter.
- **{{ amount | currency | 'USD' }}** ❌ - Incorrect, as the pipe parameter uses a colon (`:`), not a vertical bar (`|`).
- **{{ amount | currency :: '$' }}** ❌ - Incorrect, as the currency pipe expects a currency code like 'USD', not a symbol, and double colons (`::`) are invalid.

**Summary**: The correct syntax for the Angular currency pipe is `{{ amount | currency : 'USD' }}`.

> 3
**Question**: What is the `HostBinding` decorator doing in this directive?

```typescript
@Directive({
 selector: '[appHighlight]'
})
export class HighlightDirective {
 @HostBinding('class.highlighted') highlight = true;
}
```
* It is adding the CSS class named highlighted to any DOM element that has the appHighlight attribute on it. ✅ - Correct, HostBinding('class.highlighted') binds the highlight property to the highlighted class on the host element with the appHighlight attribute.
* HostBinding does not do anything on directives, it only works with components. ❌ - Incorrect, * HostBinding works in both directives and components to bind properties to the host element.
It is adding the CSS class named highlighted to any DOM element for which the tag name is appHighlight. ❌ - Incorrect, the selector [appHighlight] targets elements with the appHighlight attribute, not a tag name.
* It is creating an inline style on the host element with a CSS property named highlighted set to true. ❌ - Incorrect, HostBinding('class.highlighted') manipulates a CSS class, not an inline style.

Summary: The HostBinding decorator in the directive adds the CSS class highlighted to any DOM element with the appHighlight attribute.

> 4 
**Question**: What is the proper syntax to display a list of names in div elements when `display` is true?

- **`<ng-container *ngIf="display"> <div *ngFor="let name of names">{{name}}</div> </ng-container>`** ✅ - Correct, uses `*ngIf` on `<ng-container>` to conditionally render the list, and `*ngFor` to iterate over `names` inside separate `<div>` elements.
- **`<ng-switch *ngSwitchCase="display"> <div *ngFor="let name of names">{{name}}</div> </ng-switch>`** ❌ - Incorrect, `ngSwitch` and `ngSwitchCase` are used for switching between multiple cases, not simple conditional rendering, and the syntax is improperly structured.
- **`<ng-template *ngIf="display"> <div *ngFor="let name of names">{{name}}</div> </ng-template>`** ❌ - Incorrect, `*ngIf` on `<ng-template>` requires a template reference for rendering, and this setup won't display the content directly.
- **`<div *ngIf="display" *ngFor="let name of names"> {{name}} </div>`** ❌ - Incorrect, combining `*ngIf` and `*ngFor` on the same element is invalid Angular syntax, as structural directives cannot be combined this way.

**Summary**: The proper syntax is `<ng-container *ngIf="display"> <div *ngFor="let name of names">{{name}}</div> </ng-container>`, which conditionally renders a list of names in separate `<div>` elements when `display` is true.