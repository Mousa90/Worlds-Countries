import { Component, HostListener } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'worlds-countries';

  isVisible = false;

  // Listen to window scroll events
  @HostListener('window:scroll', [])
  onWindowScroll() {
    const scrollTop = window.scrollY || document.documentElement.scrollTop || document.body.scrollTop || 0;

    // Show the button when the scroll is more than 100px
    this.isVisible = scrollTop > 100;
  }

  // Scroll smoothly to the top when button is clicked
  scrollToTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }
}
